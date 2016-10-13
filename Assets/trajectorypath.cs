using UnityEngine;
using System.Collections;

public class trajectorypath : MonoBehaviour {
	
		private GameObject[] locationsToSpawn;
		private float counter = 0;
		[SerializeField] string[] listOfPossibleTags;
		[SerializeField] GameObject[] objectToSpawn;
		[SerializeField] float timeBetweenSpawns = 3.0f;

		void  Start (){
			locationsToSpawn = GameObject.FindGameObjectsWithTag("SpawnLocation");
		}
		void  Update (){
			counter+= Time.deltaTime;
			if(counter > timeBetweenSpawns){
				GameObject spawnedObject;
				spawnedObject = Instantiate(objectToSpawn[Random.Range(0, objectToSpawn.Length)], locationsToSpawn[Random.Range(0, locationsToSpawn.Length)].transform.position, Quaternion.identity) as GameObject;
				spawnedObject.gameObject.tag = listOfPossibleTags[Random.Range(0, listOfPossibleTags.Length)];
				counter = 0;
			}
		}
	}

