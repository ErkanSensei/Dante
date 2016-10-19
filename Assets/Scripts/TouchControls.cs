using UnityEngine;
using System.Collections;

public class TouchControls : MonoBehaviour {

	private Player thePlayer;

	void Start() {
		thePlayer = FindObjectOfType<Player> ();
	}
}
