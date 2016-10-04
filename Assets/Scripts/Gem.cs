using UnityEngine;
using System.Collections;

public class Gem : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		//Fall downwards
		float x = transform.position.x;
		float y = transform.position.y;

		while (y > 0 && !Grid.gemAt (x, y - 1))
			--y;
		transform.position = new Vector2 (x, y);
	}

	public bool sameType(Gem other) {
		return GetComponent<SpriteRenderer> ().sprite == other.GetComponent<SpriteRenderer> ().sprite;
	}
}
