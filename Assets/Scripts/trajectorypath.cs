using UnityEngine;
using System.Collections;

public class trajectorypath : MonoBehaviour {
	
	private float fallSpeed;
	private float spinSpeed = 250.0f;
	float x;
	float y;
	float z;
	Vector3 pos;

	void start(){
		x = Random.Range(-25, 100);
		y = 5;
		z = Random.Range(-25, 26);
		pos = new Vector3(x, y, z);
		transform.position = pos;
		fallSpeed = Random.Range (1, 3);
	}


	void Update() {

		Vector3 v = Quaternion.AngleAxis(Random.Range(0.0f, 360.0f), Vector3.forward) * Vector3.up;
		transform.Translate( Vector3.down * fallSpeed * Time.deltaTime , Space.World );
		transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);

	}
		


		


		}
	


	

