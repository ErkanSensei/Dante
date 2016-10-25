using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class score : MonoBehaviour {

	// Use this for initialization
	public Text CountText ;
	void Start () {
		CountText = GetComponent <Text> ();

		CountText.text = "score: ";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
