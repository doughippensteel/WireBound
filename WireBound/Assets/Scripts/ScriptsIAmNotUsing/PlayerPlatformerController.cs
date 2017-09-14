using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject {

	public float maxSpeed = 7f;
	public float jumpTakeOffSpeed = 7f;
	public float climbSpeed = 7;
	public float maxHorizontalJump = 4f;
	public bool climbable = false;
	public bool movingRight = false;
	float speed;
	float climb;
	bool jump = false;
	bool climbing = false;



	private SpriteRenderer spriteRenderer;
	private Animator anim;
	// Use this for initialization
	void Awake () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		anim = GetComponent <Animator> ();
		transform.parent = null;
	
	}

	protected override void Update()
	{
		base.Update ();


		if (Input.GetButtonDown ("Jump")) {
			jump = true;
		}

			climb = Input.GetAxis ("Vertical");

		speed = Input.GetAxis ("Horizontal");


	}
	
	protected override void ComputeVelocity()
	{
		Vector2 move = Vector2.zero;

		move.x = speed;

		if (climbable == true) {
			velocity.y = climb * climbSpeed;
		}

		if (jump && grounded) {
			velocity.y = jumpTakeOffSpeed;
			jump = false;
		} else if (jump) {
			if (velocity.y >0)
				velocity.y = velocity.y *.5f;
			jump = false;
		}

		if (speed  > 0 && !movingRight) {
			Flip ();
		} else if (speed < 0 && movingRight) {
			Flip ();
		}

	

			
		/*bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f ) : (move.x < 0.01f));
		if (flipSprite) {
			spriteRenderer.flipX = !spriteRenderer.flipX;
		}*/
		//anim.SetBool ("grounded", grounded);
		anim.SetFloat ("Speed", Mathf.Abs (velocity.x) / maxSpeed);
		if (grounded) {
			targetVelocity = move * maxSpeed;
		} else if (!grounded) {
			targetVelocity = move * maxHorizontalJump;
		}
		 

}
	void Flip()
	{
		movingRight = !movingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == ("MovingPlatform")) {
			transform.parent = other.transform;
		}
	}

	void OnCollisionExit2D (Collision2D other)
	{
		if (other.gameObject.tag == ("MovingPlatform")) {
			transform.parent = null;
		}
	}


}
