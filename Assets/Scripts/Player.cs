using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float speed = 30;
	public bool moveRight;
	public bool moveLeft;

	//Will store the last checkpoint
	Transform check;
	void Update () {
		//Move Horizontal
		float h = Input.GetAxisRaw ("Horizontal");

		if(moveRight) {
			GetComponent<Rigidbody2D> ().velocity = Vector2.right * 1 * Mathf.Clamp(speed, 0, 30);
		}

		if(moveLeft) {
			GetComponent<Rigidbody2D> ().velocity = Vector2.right * -1 * Mathf.Clamp(speed, 0, 30);
		}

		//Gravity Change
		if (Input.GetKeyDown (KeyCode.Space) && isGrounded()) {
			GetComponent<Rigidbody2D> ().gravityScale *= -1;
			transform.Rotate (0, 180, 180);
		}
		// Animation
		GetComponent<Animator>().SetInteger("DirX", (int)h);
	}
	public void MoveMeRight()
	{
		moveRight = true;
	}

	public void StopMeRight()
	{
		moveRight = false;
	}
	public void MoveMeLeft()
	{
		moveLeft = true;
	}

	public void StopMeLeft()
	{
		moveLeft = false;
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

	void OnTriggerEnter2D(Collider2D co) {

		//is it a checkpoint?
		if (co.name == "checkpoint")
			check = co.transform;
	}

	void OnCollisionEnter2D(Collision2D co) {
		//have we collided with a V?
		if (co.collider.name == "V") {
			// Reset Rotation, Gravity, Velocity and go to last Checkpoint
			transform.rotation = Quaternion.identity;
			GetComponent<Rigidbody2D>().gravityScale = Mathf.Abs(GetComponent<Rigidbody2D>().gravityScale);
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			transform.position = check.position;
		}
	}
}
