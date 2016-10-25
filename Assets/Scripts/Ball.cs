using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float speed = 100.0f;  //speed of ball
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = Vector2.up * speed;  //upwards movement
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.name == "racket"){
			float x = hitFactor (transform.position, col.transform.position, col.collider.bounds.size.x);	//calculating hit factor.
			Vector2 dir = new Vector2 (x, 1).normalized;   //Calculate the direction and set the length to 1.
			GetComponent<Rigidbody2D>().velocity = dir * speed;	//velocity = direction*speed.
		}
	}

	float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth){
		return (ballPos.x - racketPos.x) / racketWidth;	//Ball position in relation to racket.
	}
}
