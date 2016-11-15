using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class win : MonoBehaviour {
	public Text WinText;
	private int won; 
	// Use this for initialization
	void Start () {
		won =2;
	//	WinText = gameObject.GetComponent<Text> ();

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (won);
		if (won == 0)
			WinText.text = "Game Over!";
		else if (won == 1)
			WinText.text = "You Win!";
		else
			WinText.text = "";
	}

	public void Lose(bool flag){
		won = 0;
			
	}
	public void Win1(bool flag){
		won = 1;

	}
}
