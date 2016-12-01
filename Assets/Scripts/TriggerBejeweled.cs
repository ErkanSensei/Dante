using UnityEngine;
using System.Collections;

public class TriggerBejeweled : MonoBehaviour {
	public GameObject BJewel;
	public Player player;
	public GameObject[] gos;
	public GameObject[] controls;
	public GameObject[] puzzles;

	bool entered = false;

	void onTriggerEnter2D(Collider2D other) {
		Debug.Log ("Triggered");
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (!entered && other.gameObject.GetComponent<Player>() == player) {
			gos = GameObject.FindGameObjectsWithTag("Puzzle");
			controls = GameObject.FindGameObjectsWithTag ("Control");
			//loop through the returned array of game objects and set each to active false
			foreach (GameObject go in gos)  {
				go.SetActive(false);
			}
			foreach (GameObject control in controls)  {
				player.StopMeUp ();
				player.StopMeDown ();
				player.StopMeLeft ();
				player.StopMeRight ();
				control.SetActive(false);
			}
			BJewel = puzzles [Mathf.FloorToInt(Random.Range (0, puzzles.Length))];
			BJewel.SetActive (true);
			entered = true;
		}

	}
	// Update is called once per frame
	void Update () {

	}
}
