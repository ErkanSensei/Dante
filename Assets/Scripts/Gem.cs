using UnityEngine;
using System.Collections;

public class Gem : MonoBehaviour {

	// Update is called once per frame
	void Update () {
	
	}

	public bool sameType(Gem other) {
		return GetComponent<SpriteRenderer> ().sprite == other.GetComponent<SpriteRenderer> ().sprite;
	}
}
