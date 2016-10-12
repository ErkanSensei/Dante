using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float speed = 100.0f;  //speed of ball
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = Vector2.up * speed;
	}
}
