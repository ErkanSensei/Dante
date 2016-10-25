using UnityEngine;
using System.Collections;

public class Racket : MonoBehaviour {

	public float speed = 150;  //Movement speed of racket.

	// Use this for initialization
	void FixedUpdate(){

		// Moves object according to finger movement on the screen
		if (Input.touchCount > 0 &&
		     Input.GetTouch (0).phase == TouchPhase.Moved) {

			// Get movement of the finger since last frame
			Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;

			// Move object across XY plane
			transform.Translate (-touchDeltaPosition.x * speed, 
				-touchDeltaPosition.y * speed, 0);
		}
	}
		//float yInput = Input.GetAxisRaw ("Horizontal");	// Horizontal input.
		//GetComponent<Rigidbody2D>().velocity = Vector2.right * pointer_y * speed
}

