﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilterController : MonoBehaviour {

	//scale for gates is differnet for box and ball
	//box: 34.0469
	//ball: 32

	public float velocity;

	public float rotiationVelocity;

	public bool rightPress;

	public bool leftPress;

	private Rigidbody2D body;
	// Use this for initialization
	void Start () {
		body = transform.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		// transform.Translate(Vector3.up * velocity * Time.deltaTime, Space.World);
		body.velocity = Vector3.up*velocity;
		Rotate();
	}

	public void Rotate() {
		if (leftPress) {
			transform.Rotate(Vector3.forward * Time.deltaTime * rotiationVelocity);
		}
		if (rightPress) {
			transform.Rotate(-Vector3.forward * Time.deltaTime * rotiationVelocity);
		}	
	}

	public void updateButtonHeld(bool left) {
		if (left) {
			leftPress = true;
		}
		else {
			rightPress = true;
		}
	}

	public void updateButtonUp(bool left) {
		if (left) {
			leftPress = false;
		}
		else{
			rightPress = false;
		}
	}
}
