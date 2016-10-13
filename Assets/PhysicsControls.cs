using UnityEngine;
using System.Collections;

public class PhysicsControls : MonoBehaviour
{
	public float speed = 1.5f;

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

	}
}
