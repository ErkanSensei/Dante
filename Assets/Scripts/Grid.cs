using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	public static int w = 8;
	public static int h = 8;

	//Available Gems
	public GameObject[] gems;

	// Update is called once per frame
	void Update () {
		//Spawn Gem in empty spaces of top row
		for (int x = 0; x < w; ++x)
			if (!gemAt (x, h - 1))
				spawnAt (x, h - 1);
	}

	public static Gem gemAt(float x, float y) {
		//Find Gem at Position (x,y)
		Gem[] gems = GameObject.FindObjectsOfType<Gem>();
		foreach(Gem g in gems)
			if ((Vector2)g.transform.position == new Vector2(x,y))
				return g;
		return null;
	}

	void spawnAt(float x, float y) {
		int index = Random.Range (0, gems.Length);
		Instantiate (gems [index], new Vector2 (x, y), Quaternion.identity);
	}
}
