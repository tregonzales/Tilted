using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateCover : MonoBehaviour {

	SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.color = Camera.main.backgroundColor;
	}
	
	// Update is called once per frame
	void Update () {
		spriteRenderer.color = Camera.main.backgroundColor;
	}
}
