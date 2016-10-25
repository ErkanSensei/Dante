using UnityEngine;
using System.Collections;

public class Hexagon : MonoBehaviour {
	public GameObject[] rotations;
	public bool[] currentRotations;
	public double[] winningRotations;
	public bool rotateOrNo = true;
	public GameObject[] gos;
	public GameObject[] controls;
	
	// Update is called once per frame
	void Update () {
		checkIfWinning ();
	}

	public void rotateThis(GameObject hexagon) {
		hexagon.transform.Rotate (0, 0, 60);
	}

	public void checkIfWinning() {
		for (int i = 0; i < rotations.Length; i++) {
			if (winningRotations [i] == Mathf.Floor (rotations [i].transform.localEulerAngles.z)) {
				currentRotations [i] = true;
			} else {
				currentRotations [i] = false;
			}
		}
		for (int j = 0; j < rotations.Length; j++) {
			if (currentRotations [j] == false) {
				rotateOrNo = false;
			}
		}

		if (rotateOrNo == true) {
			Debug.Log ("Winner!");
			gos = GameObject.FindGameObjectsWithTag("Puzzle");
			//loop through the returned array of game objects and set each to active false
			foreach (GameObject go in gos)  {
				go.SetActive(false);
				Destroy (go);
			}
			foreach (GameObject control in controls)  {
				control.SetActive(true);
			}

		}
		rotateOrNo = true;
	}
}
