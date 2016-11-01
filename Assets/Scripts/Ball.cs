using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float speed = 100.0f;  //speed of ball
	public Vector3 initialPosition;
	public Quaternion initialRotation;
	public AudioClip walkSound;
	private AudioSource source;
	private float volLowRange = .2f;
	private float volHighRange = .2f;
	private float vol;

	void Awake() {
		source = GetComponent<AudioSource>();
	}
	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
		GetComponent<Rigidbody2D> ().velocity = Vector2.up * speed;  //upwards movement
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.name == "racket"){
			float x = hitFactor (transform.position, col.transform.position, col.collider.bounds.size.x);	//calculating hit factor.
			Vector2 dir = new Vector2 (x, 1).normalized;   //Calculate the direction and set the length to 1.
			GetComponent<Rigidbody2D>().velocity = dir * speed;	//velocity = direction*speed.
		}
		vol = Random.Range (volLowRange, volHighRange);
		source.PlayOneShot (walkSound, vol);
	}

	float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth){
		return (ballPos.x - racketPos.x) / racketWidth;	//Ball position in relation to racket.
	}

	public Vector3 getIP() {
		return initialPosition;
	}
}
