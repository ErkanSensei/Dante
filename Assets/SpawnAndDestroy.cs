using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnAndDestroy : MonoBehaviour {

	private float endTime;
	public Text text;
	public GameObject door;
	public GameObject[] controls;
	public GameObject[] gos;
	private SpriteRenderer sprite;
	// Use this for initialization
	void Start () {
		endTime = Time.time + 6;
		text.text = "7";
	}
	
	// Update is called once per frame
	void Update () {
		int timeLeft = (int)(endTime - Time.time);
		if (timeLeft < 0) {
			timeLeft = 0;
		}
		text.text = timeLeft.ToString ();
		if (text.text == "0") {
			gos = GameObject.FindGameObjectsWithTag ("Puzzle");
			foreach (GameObject go in gos)  {
				go.SetActive(false);
				Destroy (go);
			}
			foreach (GameObject control in controls)  {
				control.SetActive(true);
			}
			gameObject.SetActive (false);
			sprite = door.GetComponent<SpriteRenderer> ();
			sprite.sortingOrder = -1;
		}
	}
}
