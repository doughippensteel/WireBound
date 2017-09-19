using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour {
	#region PublicVariables
	public float maxSpeed = 10f;
	public float jumpForce = 700f;
	public float climbSpeed = 7f;
	public float gravityBase = 5;
	public bool climbable = false;
	public bool jump = false;
	#endregion

	#region PrivateVariables
	private float groundRadius = 0.2f;
	float moveX;
	float moveY;
	[SerializeField]
	bool movingRight = true;
	[SerializeField]
	bool grounded = false;
	#endregion

	#region GameObjectsAndComponets
	public Transform groundCheck;
	public LayerMask whatIsGround;

	private Rigidbody2D rig;
	private SpriteRenderer spriteRend;
	private Animator anim;


	#endregion


	// Use this for initialization
	void Awake () {

		rig = this.gameObject.GetComponent<Rigidbody2D> ();
		spriteRend = gameObject.GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();

		transform.parent = null;

	}
	void Start(){
		
	}
	// Update is called once per frame
	 void Update () {

		#region PlayerInputs
		 moveX = Input.GetAxis ("Horizontal");
		 moveY = Input.GetAxis ("Vertical");

		if ((grounded || climbable) && Input.GetButtonDown ("Jump")) 
		{
			jump = true;

		}else {
			jump = false;
		}
		#endregion

		if (climbable && !grounded) {
			rig.gravityScale = 0;
		} else {
			rig.gravityScale = gravityBase;
		}

	}

	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

		rig.velocity = new Vector2 ( moveX * maxSpeed, rig.velocity.y);

		if (jump == true) {
			rig.AddForce (new Vector2 (0, jumpForce));
		}

		if (moveX > 0 && !movingRight) {
			Flip ();
		} else if (moveX < 0 && movingRight) {
			Flip ();
		}


		if (climbable == true) {
			rig.velocity = new Vector2 (rig.velocity.x, moveY * climbSpeed);
		}

	

		anim.SetFloat ("Speed", Mathf.Abs (moveX));
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