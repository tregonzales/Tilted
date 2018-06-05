using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boxController : MonoBehaviour {

	public Text scoreText;
	private int score = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateScore() {
		score++;
		scoreText.text = score.ToString();
	}
}
