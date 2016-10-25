using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float speed = 10;
	public bool moveRight, moveLeft, moveUp, moveDown;


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

		if(moveUp) {
			GetComponent<Rigidbody2D> ().velocity = Vector2.up * 1 * Mathf.Clamp(speed, 0, 30);
		}
		if(moveDown) {
			GetComponent<Rigidbody2D> ().velocity = Vector2.up * -1 * Mathf.Clamp(speed, 0, 30);
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
		speed = 10;
		GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
		GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
	}

	public void StopMeRight()
	{
		moveRight = false;
		GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
		speed = 0;
	}
	public void MoveMeLeft()
	{
		moveLeft = true;
		speed = 10;
		GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
		GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
	}

	public void StopMeLeft()
	{
		moveLeft = false;
		GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
		speed = 0;
	}
		
	public void MoveMeUp()
	{
		moveUp = true;
		speed = 10;
		GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
		GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
	}

	public void StopMeUp()
	{
		moveUp = false;
		GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
		speed = 0;
	}
	public void MoveMeDown()
	{
		moveDown = true;
		speed = 10;
		GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
		GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
	}

	public void StopMeDown()
	{
		moveDown = false;
		GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
		speed = 0;
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
