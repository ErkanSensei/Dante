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
		if (Input.GetKeyDown (KeyCode.Space) && isGrounded()) {
			GetComponent<Rigidbody2D> ().gravityScale *= -1;
			transform.Rotate (0, 180, 180);
		}
		// Animation
		GetComponent<Animator>().SetInteger("DirX", (int)h);
	}

	public bool isGrounded() {
		// Get Bounds and Cast Range (extents.y+20%)
		Bounds bounds = GetComponent<Collider2D>().bounds;
		float range = bounds.extents.y * 1.2f;

		// Calculate a position slightly 'below' the collider
		// (via transform.up so it's gravity tolerant)
		Vector2 v = bounds.center - transform.up * range;

		// Linecast upwards
		RaycastHit2D hit = Physics2D.Linecast(v, bounds.center);

		// Was there something in-between, or did we hit ourself?
		return (hit.collider.gameObject != gameObject);
	}
}
