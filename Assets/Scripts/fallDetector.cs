using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallDetector : MonoBehaviour {

	//offset on y axis from tilter
	public float offsetY;

	//tilter which is parent
	public Transform tilter;

	//script for tilter
	private tilterController tilterController;

	//the ball script
	public ballController ball;

	// Use this for initialization
	void Start () {
		tilterController = tilter.GetComponent<tilterController>();
	}
	
	void Update () {
		transform.position = new Vector3(tilter.position.x, tilter.position.y - offsetY, 0);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			ball.loseAnimation();
			tilterController.loseAnimation();
		}
	}
}
