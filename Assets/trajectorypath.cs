using UnityEngine;
using System.Collections;

public class trajectorypath : MonoBehaviour {
	
	public float fallSpeed = 8.0f;
	public float spinSpeed = 250.0f;

	void Update() {

		Vector3 v = Quaternion.AngleAxis(Random.Range(0.0f, 360.0f), Vector3.forward) * Vector3.up;
		transform.Translate( Vector3.down * fallSpeed * Time.deltaTime , Space.World );
		transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);

	}
		


		


		}
	


	

