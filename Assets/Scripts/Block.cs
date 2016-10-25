using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	public GameObject door;
	public GameObject[] controls;
	public GameObject[] gos;
	private SpriteRenderer sprite;

	void OnCollisionEnter2D(Collision2D collisionInfo){
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
