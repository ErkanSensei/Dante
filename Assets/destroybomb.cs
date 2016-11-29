using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class destroybomb : MonoBehaviour {

	//Collision col;
	// Use this for initialization
	//public float speed;

	private  Vector3 velocity ;
	public float speed = 10f;
	public Text WordText;
	//public Text WinText;
	public string[]  Word;
	public static int i = 0; 

	private int count;
	private static int score; 
	float num =  0.3f;

	void Start ()
	{
		WordText = GetComponent <Text> ();
		
		//WordText = new Text;
		//count = new int ();

	}



	void OnCollisionEnter2D (Collision2D col)
	{
		Debug.Log ("Tell me something"); 

		if (col.gameObject.name == "catcher") {
			//WordText.IsActive = true;
			WordText = GetComponent <Text> ();
			Debug.Log ("Object collided");


			Destroy (gameObject);
			Application.Quit ();




			//gameObject.active = false;
		} 

		if (col.gameObject.name==( "clouds")) {
			
			Debug.Log ("Object collided");


			Destroy (gameObject);





			//gameObject.active = false;
		} 

		if (gameObject.name== "cann") {
			WordText = GetComponent <Text> ();
			Debug.Log ("Object collided");
			score-=10;

			Destroy (gameObject);





			//gameObject.active = false;
		} 
		if (col.gameObject.name== "Panel" || col.gameObject.name == "Canvas") {
			WordText = GetComponent <Text> ();
			//Debug.Log ("Object collided");	
			Destroy (gameObject);


		} 



}
	void Update(){
		
		WordText.text = " Game Over";
		if (score >= 40) {
			Debug.Log ("WIn Function Called!");

			 new WaitForSeconds(5f);
			Debug.Log ("COMPLETE");
			Application.Quit();
		}
			
	}


}

