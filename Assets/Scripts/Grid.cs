﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour {

	public static int w = 13;
	public static int h = 10;

	//Available Gems
	public GameObject[] gems;

	// Update is called once per frame
	void Update () {

		spawnGems ();
	}

	public static void destroyBoard() {
		List<Gem> listOfGems = new List<Gem> ();
		Debug.Log ("Destroy");
		for (int i = 0; i < w; ++i) {
			for (int j = 0; j < h; ++j) {
				listOfGems.Add (gemAt (i, j));
			}
		}

		solveMatches (listOfGems);
	}
	public void spawnGems() {
		//Spawn gems
		for (int x = 0; x < w; ++x) {
			if (!gemAt (x, h - 1))
				spawnAt (x, h - 1);
			//If there's something below the gem, then solve matches for it
			if (gemAt (x, h - 2))
				solveMatches (matchesAt (x, h - 1));
		}
	}
	public static Gem gemAt(float x, float y) {
		//Find Gem at Position (x,y)
		Gem[] gems = GameObject.FindObjectsOfType<Gem>();
		foreach(Gem g in gems)
			if ((Vector2)g.transform.position == new Vector2(x,y))
				return g;
		return null;
	}

	public static List<Gem> matchesAt(float x, float y) {
		List<Gem> res = new List<Gem> ();
		Gem center = Grid.gemAt (x, y);
		//check horizontally
		List<Gem> hor = new List<Gem>();
		hor.Add (center); // add your original gem
		if (Grid.gemAt (x + 1, y) && Grid.gemAt (x + 1, y).sameType (center)) {
			hor.Add (Grid.gemAt (x + 1, y));
			if (Grid.gemAt (x + 2, y) && Grid.gemAt (x + 2, y).sameType (center))
				hor.Add (Grid.gemAt (x + 2, y));

		}
		if (Grid.gemAt (x - 1, y) && Grid.gemAt (x - 1, y).sameType (center)) {
			hor.Add (Grid.gemAt (x - 1, y));
			if (Grid.gemAt (x - 2, y) && Grid.gemAt (x - 2, y).sameType (center))
				hor.Add (Grid.gemAt (x - 2, y));

		}
		//if the count of gems next to each other are 3 or more, add to res
		if (hor.Count >= 3) {
			res.AddRange (hor);
		}
		//check vertically
		List<Gem> ver = new List<Gem> ();
		ver.Add (center);
		if (Grid.gemAt (x, y + 1) && Grid.gemAt (x, y + 1).sameType (center)) {
			ver.Add (Grid.gemAt (x, y + 1));
			if (Grid.gemAt (x, y + 2) && Grid.gemAt (x, y + 2).sameType (center))
				ver.Add (Grid.gemAt (x, y + 2));
		}
		if (Grid.gemAt (x, y - 1) && Grid.gemAt (x, y - 1).sameType (center)) {
			ver.Add (Grid.gemAt (x, y - 1));
			if (Grid.gemAt (x, y - 2) && Grid.gemAt (x, y - 2).sameType (center))
				ver.Add (Grid.gemAt (x, y - 2));
		}
		if (ver.Count >= 3) {
			res.AddRange (ver);
		}

		return res;
	}
	public static void solveMatches(List<Gem> matches) {
		foreach (Gem g in matches)
			Destroy (g.gameObject);
	}
	void spawnAt(float x, float y) {
		int index = Random.Range (0, gems.Length);
		Instantiate (gems [index], new Vector2 (x, y), Quaternion.identity);
	}
}
