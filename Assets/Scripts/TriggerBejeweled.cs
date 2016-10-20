using UnityEngine;
using System.Collections;

public class TriggerBejeweled : MonoBehaviour {
	public GameObject BJewel;
	bool entered = false;

	void onTriggerEnter2D(Collider2D other) {
		Debug.Log ("Triggered");
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (!entered) {
			Debug.Log ("TriggeredStay");
			BJewel.SetActive (true);
			entered = true;
		}

	}
	// Update is called once per frame
	void Update () {

	}
}
