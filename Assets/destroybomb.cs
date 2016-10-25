using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class destroybomb : MonoBehaviour {

	//Collision col;
	// Use this for initialization
	//public float speed;
	public win WIN1;
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
		
		//WordText = new Text;
		//count = new int ();
		WIN1 = GameObject.Find("WinText").GetComponent<win>();
		//WIN1 = gameObject.GetComponent<win>(); 
	//	WinText = GetComponent<Text>();
		Word = new string[10]; 
		Word [0] = "C";
		Word [1] = "A";
		Word [2] = "T";
		WordText = GetComponent <Text> ();
		Debug.Log(WordText);
		count = 0;
		WordText.text = "_ _ _";
	//	SetCountText ();
		//winText.text = "";

	}


	void OnCollisionEnter2D (Collision2D col)
	{
		Debug.Log ("Tell me something"); 

		if (col.gameObject.name== "catcher") {
			WordText = GetComponent <Text> ();
			Debug.Log ("Object collided");
			score+=5;

			Destroy (gameObject);





			//gameObject.active = false;
		} 

		if (gameObject.name.Contains( "MiniBomb")) {
			WordText = GetComponent <Text> ();
			Debug.Log ("Object collided");
			score+=10;

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
		
		WordText.text = "score: " + score.ToString ();	
		if (score >= 40) {
			Debug.Log ("WIn Function Called!");
			WIN1.WinText.text= "You Win!";
			 new WaitForSeconds(5f);
			Debug.Log ("COMPLETE");
			Application.Quit();
		}
			
	}


}

