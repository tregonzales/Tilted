using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateController : MonoBehaviour {

	public bool passed;
	// Use this for initialization
	void Start () {
		passed = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//has collided with wall or gate wall, lose condition
	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag("Player") && !passed) {
			Debug.Log("got heeeem");
			other.GetComponent<ballController>().loseAnimation();
		}
	}
}
