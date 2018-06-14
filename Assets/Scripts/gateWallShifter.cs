using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateWallShifter : MonoBehaviour {

	//left least position
	public float minX;

	//left most position
	public float maxX;

	//the goal that indicates passing the current gate
	public GameObject gateGoal;

	// Use this for initialization
	void Start() {
		//shift the gate at a random position across the x axis within the range
		transform.localPosition = new Vector3(Random.Range(minX, maxX), transform.localPosition.y, 0);

		//make sure the gate goal comes along with it
		gateGoal.transform.position = new Vector3(transform.position.x, gateGoal.transform.position.y, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
