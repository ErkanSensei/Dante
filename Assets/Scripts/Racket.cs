using UnityEngine;
using System.Collections;

public class Racket : MonoBehaviour {

	public float speed = 150;  //Movement speed of racket.

	// Use this for initialization
	void FixedUpdate(){
	
		float yInput = Input.GetAxisRaw ("Horizontal");	// Horizontal input.
		GetComponent<Rigidbody2D>().velocity = Vector2.right * yInput * speed;
	}
}
