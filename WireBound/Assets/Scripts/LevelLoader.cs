using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ColorToPrefab {
	public Color32 color;
	public GameObject prefab;

}

public class LevelLoader : MonoBehaviour {

	public Texture2D levelMap;

	public ColorToPrefab[] colorToPrefab;





	// Use this for initialization
	void Start () {
		LoadMap ();
	}

	void EmptyMap(){
	// Destroy all child objects of Map

		while (transform.childCount > 0) {
			Transform c = transform.GetChild (0);
			c.SetParent (null); //Unparent child. Important to avoid infinite loop! Destroy called at end of update!
			Destroy (c.gameObject); //Desrtoys Object.
		}
	}

	void LoadMap(){
		EmptyMap ();

		// Get raw pixels from map image

		Color32[] allPixels = levelMap.GetPixels32 ();
		int width = levelMap.width;
		int height = levelMap.height;

		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {

				TileSpawner (allPixels [(y * width) + x], x, y);
			}
		}
		
	}

	void TileSpawner (Color32 c, int x, int y){
		// Ignore Transparent Pixel

		if (c.a <= 0) {
			return;
		}

		// Find the right color in map

		//TODO Optimize with dictionary lookup to increase speed.
		foreach (ColorToPrefab ctp in colorToPrefab) {
			if (c.Equals(ctp.color)){
				// Spawb tile at location
				GameObject tile = Instantiate(ctp.prefab, new Vector3(x, y, 0), Quaternion.identity);
				tile.transform.SetParent (this.transform);
				return;
			}
		}

		//No Matching color.

		Debug.LogError ("No prefab match forund for" + c.ToString ());
	}
}
