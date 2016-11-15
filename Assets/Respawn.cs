using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

	public Transform[] teleport;
	private float x; 
	private float y;
	public GameObject[] prefeb;

	void  Start(){ //this will spawn only one prefeb, if you want call it many time, create  a new function and call it or create for loop
		int tele_num = Random.Range(0,1);
		int prefeb_num = Random.Range(0,3);
		Vector3 x_position = transform.position; // get a copy
		x= Random.Range(-105,60);
		y= Random.Range(60,130);
		x_position = new Vector3 (x, y);
	 //Instantiate(prefeb) as GameObject;
		Instantiate (prefeb [prefeb_num], x_position, teleport [tele_num].rotation);

	}

	IEnumerable wait(){
		yield return new WaitForSecondsRealtime (3);


	}

}
