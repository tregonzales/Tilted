using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateGoal : MonoBehaviour {

	private GameObject gateGoalHolder;

	Animation gateFade;

	// Use this for initialization
	void Start () {
		gateGoalHolder = transform.parent.gameObject;
		gateFade = gateGoalHolder.GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			// other.GetComponent<boxController>().updateScore();
			other.GetComponent<ballController>().updateScore();
			gateFade.Play();
			Destroy(gateGoalHolder, gateFade.clip.length);
		}
	}
}
