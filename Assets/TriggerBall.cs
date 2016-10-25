using UnityEngine;
using System.Collections;

public class TriggerBall : MonoBehaviour {
	public Ball ball;
	// Use this for initialization

	void OnTriggerEnter2D(Collider2D go) {
		Debug.Log ("Trigger");
		ball.transform.position = ball.getIP();
	}
}
