using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {


	public Transform[] backgrounds;					//Array of backgrounds, foregrounds for parallaxing
	private float[] parallaxScales; 					//Proportion of camera movement for backgrounds
	public float smoothing = 1f;					//Smoothness of parallax

	private Transform cam;							//reference to main camera transform
	private Vector3 previousCamPosition;			//Position of camera in previous frame

	void Awake(){
		cam = Camera.main.transform;				//Camera reference set up
	}


	// Use this for initialization
	void Start () {
		previousCamPosition = cam.position;

		parallaxScales = new float[backgrounds.Length];

		for (int i = 0; i < backgrounds.Length; i++) {
			parallaxScales[i] = backgrounds[i].position.z * -1;
		}
	}
	
	// Update is called once per frame
	void Update () {

		for (int i = 0; i < backgrounds.Length; i++){
			float parallax = (previousCamPosition.x - cam.position.x) * parallaxScales[i];
			float backgroundTargetPositionX = backgrounds[i].position.x + parallax;		//target x position
			Vector3 backgroundTargetPosition = new Vector3 (backgroundTargetPositionX, backgrounds[i].position.y, backgrounds[i].position.z);

			backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPosition, smoothing * Time.deltaTime); 	//Fade between current position and target position.
		}
		previousCamPosition = cam.position;		//set previous cam position to the camera position at the end of frame.
	}
}
