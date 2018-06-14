using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateCover : MonoBehaviour {

	//sprite to cover the excess gate wall that is outside of the boundary walls
	SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		//match the camera's background
		spriteRenderer.color = Camera.main.backgroundColor;
	}
	
	// Update is called once per frame
	void Update () {
		//make sure to have same color as the camera as it changes throughout play
		spriteRenderer.color = Camera.main.backgroundColor;
	}
}
