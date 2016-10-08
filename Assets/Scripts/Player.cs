using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float speed = 30;
	// Update is called once per frame
	void Update () {
		//Move Horizontal
		float h = Input.GetAxisRaw ("Horizontal");
		GetComponent<Rigidbody2D> ().velocity = Vector2.right * h * speed;

		//Gravity Change
		if (Input.GetKeyDown (KeyCode.Space)) {
			GetComponent<Rigidbody2D> ().gravityScale *= -1;
			transform.Rotate (0, 180, 180);
		}
		// Animation
		GetComponent<Animator>().SetInteger("DirX", (int)h);
	}
}
