using UnityEngine;
using System.Collections;

public class ballReset : MonoBehaviour {
	public Vector3 initialPosition;
	Ball instance = new Ball();
	void OnTriggerEnter(Collider go){
		// Add some checks to make sure the go (gameobject) is the ball
		transform.position = initialPosition;
	}
}
