using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateSpawner : MonoBehaviour {

	//spawning these
	public GameObject gatePrefab;

	//how far should each gate be from each other on y axis
	public float distance;

	//how many to spawn
	public int spawnNum;

	//current point on y axis to spawn gate
	private float currentYtrans = 0;

	// Use this for initialization
	void Start () {
		//make first ten
		createGates(false);
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void createGates(bool midPlay = true) {
		Vector3 position;

		//only create ten gates if we are playing
		//create spawnnum gates to start the game
		//spawnnum should be greater than 10 so esthat we always have a few extra as the player passes gat
		spawnNum = midPlay ? 10 : spawnNum; 
		for (int i = 0; i < spawnNum; i++) {
			//set position as the next point in the y axis
			position = new Vector3(0, currentYtrans, 0);
			//make this object
			Instantiate(gatePrefab, position, Quaternion.identity);
			//keep moving up the y axis
			currentYtrans += distance;
		}
	}
}
