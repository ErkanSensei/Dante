using UnityEngine;
using System.Collections;

public class Hexagon : MonoBehaviour {
	public GameObject[] rotations;
	public bool[] currentRotations;
	public double currentRotation;
	public double[] winningRotations;
	public double winningRotation;
	public bool rotateOrNo = false;
	
	// Update is called once per frame
	void Update () {
		checkIfWinning ();
	}

	public void rotateThis(GameObject hexagon) {
		Debug.Log (Mathf.Floor(hexagon.transform.localEulerAngles.z));
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
	}
}
