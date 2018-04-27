using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {
	public GameObject duck;
	public Transform[] waypoints;
	public int numberOfSpawnElements = 1;
	public int spawnInterval = 5;

	private int nextTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time >= nextTime){
			spawnDuck ();
			nextTime = Mathf.FloorToInt (Time.time) + spawnInterval;
		}

	}

	public void spawnDuck(){
		GameObject newDuck = Instantiate (duck) as GameObject;
		Transform[] randomPoints = getRandomPoint ();
		for (int i = 0; i < randomPoints.Length; i++) {
			newDuck.transform.position = randomPoints[i].position	;
		}
		Debug.Log(getRandomPoint().Length);
	}

	private Transform[] getRandomPoint(){
		int min = 0;
		int max = waypoints.Length;
		Transform[] randomPoints = new Transform[numberOfSpawnElements];
		for(int i = 0; i < numberOfSpawnElements; i++){
			randomPoints[i] = waypoints[Random.Range(min, max)];
		}
		return randomPoints;
	}
}
