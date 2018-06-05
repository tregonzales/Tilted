using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateWallShifter : MonoBehaviour {

	public float minX;
	public float maxX;
	public GameObject gateGoal;

	// Use this for initialization
	void Start() {
		transform.localPosition = new Vector3(Random.Range(minX, maxX), transform.localPosition.y, 0);
		gateGoal.transform.position = new Vector3(transform.position.x, gateGoal.transform.position.y, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
