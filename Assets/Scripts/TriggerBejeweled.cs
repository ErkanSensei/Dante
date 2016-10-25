using UnityEngine;
using System.Collections;

public class TriggerBejeweled : MonoBehaviour {
	public GameObject BJewel;
	public Player player;
	public GameObject[] gos;
	public GameObject[] controls;

	bool entered = false;

	void onTriggerEnter2D(Collider2D other) {
		Debug.Log ("Triggered");
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (!entered) {
			gos = GameObject.FindGameObjectsWithTag("Puzzle");
			controls = GameObject.FindGameObjectsWithTag ("Control");
			//loop through the returned array of game objects and set each to active false
			foreach (GameObject go in gos)  {
				go.SetActive(false);
				Destroy (go);
			}
			foreach (GameObject control in controls)  {
				player.StopMeUp ();
				player.StopMeDown ();
				player.StopMeLeft ();
				player.StopMeRight ();
				control.SetActive(false);
			}
			BJewel.SetActive (true);
			entered = true;
		}

	}
	// Update is called once per frame
	void Update () {

	}
}
