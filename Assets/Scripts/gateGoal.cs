using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateGoal : MonoBehaviour {

	//object that holds whole gate (also the parent)
	private GameObject gateGoalHolder;

	//to fade the entire object away when completing
	Animation gateFade;

	// Use this for initialization
	void Start () {
		gateGoalHolder = transform.parent.gameObject;
		gateFade = gateGoalHolder.GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//successfully passed this gate
	void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			//update the score
			other.GetComponent<ballController>().updateScore();
			//fade the gate to nothing
			gateFade.Play();
			//destroy the whole parent object when animation has completed
			Destroy(gateGoalHolder, gateFade.clip.length);
			Debug.Log("passed");
		}
	}
}
