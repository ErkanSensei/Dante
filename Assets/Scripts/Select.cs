using UnityEngine;
using System.Collections;

public class Select : MonoBehaviour {
	//Current selection
	float x = 0;
	float y = 0;

	//Visual Indicator
	public Transform selectRect;
	// Update is called once per frame
	void Update () {
		//Get Gem at (x, y)
		Gem selected = Grid.gemAt(x,y);
		if (selected != null) {
			if (Input.GetKeyDown (KeyCode.UpArrow) && Grid.gemAt (x, y + 1)) {
				if (Input.GetKey (KeyCode.LeftShift)) {
					if (validSwap (selected, Grid.gemAt (x, y + 1))) {
					}
				} else
					++y;
			} else if (Input.GetKeyDown (KeyCode.DownArrow) && Grid.gemAt (x, y - 1)) {
				if (Input.GetKey (KeyCode.LeftShift)) {
					if (validSwap (selected, Grid.gemAt (x, y - 1))) {
					}
				} else
					--y;
			} else if (Input.GetKeyDown (KeyCode.RightArrow) && Grid.gemAt (x + 1, y)) {
				if (Input.GetKey (KeyCode.LeftShift)) {
					if (validSwap (selected, Grid.gemAt (x + 1, y))) {
					}
				} else
					++x;
			} else if (Input.GetKeyDown (KeyCode.LeftArrow) && Grid.gemAt (x - 1, y)) {
				if (Input.GetKey (KeyCode.LeftShift)) {
					if (validSwap (selected, Grid.gemAt (x - 1, y))) {
					}
				} else
					--x;
			}
		}
		selectRect.position = new Vector2 (x, y);
	}
	void swap(Gem a, Gem b) {
		Vector2 temp = a.transform.position;
		a.transform.position = b.transform.position;
		b.transform.position = temp;
	}

	bool validSwap(Gem a, Gem b) {
		//Swap is valid if it results in a match
		swap(a, b);
		bool res = Grid.matchesAt (a.transform.position.x, a.transform.position.y).Count > 0 ||
		           Grid.matchesAt (b.transform.position.x, b.transform.position.y).Count > 0;
		swap (a, b);
		return res;
	}
}
