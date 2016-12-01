using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private Animator animator;
	public float speed = 10;
	public bool moveRight, moveLeft, moveUp, moveDown;
	public AudioClip walkSound;
	public int counter;
	private AudioSource source;
	private float volLowRange = .2f;
	private float volHighRange = .2f;
	private float vol;

	//Will store the last checkpoint
	Transform check;

	void Awake() {
		source = GetComponent<AudioSource>();
		animator = this.GetComponent<Animator> ();
		counter = 0;
	}
	void Update () {
		//Move Horizontal
		float h = Input.GetAxisRaw ("Horizontal");
		counter++;
		if (moveRight) {
			GetComponent<Rigidbody2D> ().velocity = Vector2.right * 1 * Mathf.Clamp (speed, 0, 30);
			vol = Random.Range (volLowRange, volHighRange);
			if (counter % 10 == 0) {
				source.PlayOneShot (walkSound, vol);
			}
			animator.SetInteger ("Direction", 1);
		} else if (moveLeft) {
			GetComponent<Rigidbody2D> ().velocity = Vector2.right * -1 * Mathf.Clamp (speed, 0, 30);
			vol = Random.Range (volLowRange, volHighRange);
			if (counter % 10 == 0) {
				source.PlayOneShot (walkSound, vol);
			}
			animator.SetInteger ("Direction", 2);
		} else if (moveUp) {
			GetComponent<Rigidbody2D> ().velocity = Vector2.up * 1 * Mathf.Clamp (speed, 0, 30);
			vol = Random.Range (volLowRange, volHighRange);
			if (counter % 10 == 0) {
				source.PlayOneShot (walkSound, vol);
			}
			animator.SetInteger ("Direction", 3);
		} else if (moveDown) {
			GetComponent<Rigidbody2D> ().velocity = Vector2.up * -1 * Mathf.Clamp (speed, 0, 30);
			vol = Random.Range (volLowRange, volHighRange);
			if (counter % 10 == 0) {
				source.PlayOneShot (walkSound, vol);
			}
			animator.SetInteger ("Direction", 0);
		} else {
			animator.SetInteger ("Direction", 4);
		}
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
