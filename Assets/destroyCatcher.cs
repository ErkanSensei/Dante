using UnityEngine;
using System.Collections;

public class destroyCatcher : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D col)
	{

		if (col.gameObject.name == "Panel" || col.gameObject.name.Contains( "Canvas") ){
			
			Destroy (gameObject);

		}
	}
}
