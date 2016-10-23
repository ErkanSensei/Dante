using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class countdown : MonoBehaviour {
	public Text CountText;
	public float timeleft;
	 win WIN; 
	// Use this for initialization
	void Start () {
		WIN = gameObject.GetComponent<win>(); 
		CountText = GetComponent<Text> ();
		timeleft= 15.0f;

	}
	
	// Update is called once per frame
	void Update () {
	
		CountText.text = "Time: " + timeleft.ToString ();
		timeleft -= Time.deltaTime;
		Debug.Log ("time: " + timeleft);
		if ( timeleft <=0 )
		{
			timeleft = 0;
			Debug.Log ("time is up");
			WIN.Lose (false);
			GameOver();

		}


	}
	public void GameOver(){
		Application.Quit();
	}
}
