using UnityEngine;
using System.Collections;

public class start : MonoBehaviour {
	public GameObject startButton;
	public GameObject [] controls;
	// Use this for initialization
	public void pressStart() {
		foreach (GameObject g in controls) {
			g.SetActive (true);

		}
		Destroy (startButton);
	}
}
