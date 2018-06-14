using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//has collided with wall or gate wall, lose condition
	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag("Player")) {
			Debug.Log("got heeeem");
			other.GetComponent<ballController>().loseAnimation();
		}
	}
}
