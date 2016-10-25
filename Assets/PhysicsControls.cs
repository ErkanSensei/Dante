using UnityEngine;
using System.Collections;

public class PhysicsControls : MonoBehaviour
{
	public float speed = 1.5f;
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

	}
	void Update ()
	{
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position += Vector3.left * speed * Time.deltaTime;

		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.position += Vector3.up * speed * Time.deltaTime;

		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.position += Vector3.down * speed * Time.deltaTime;
		}

	}
}
