using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class countdown : MonoBehaviour {
	public Text CountText;
	private float timeleft = 7.0f;
	 win WIN; 
	// Use this for initialization
	void Start () {
		WIN = GameObject.Find("WinText").GetComponent<win>(); 
		CountText = GameObject.Find("Count Text").GetComponent<Text> ();
		//timeleft= 10.0f;

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
			WIN.WinText.text = ("Game Over");
			GameOver();

		}


	}
	public void GameOver(){
		Application.Quit();
	}
}
