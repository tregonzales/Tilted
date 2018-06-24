using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreController : MonoBehaviour {


	Text scoreText;
	public bool playScoreCounter;
	private Text colorText;
	private int numDigits;

	//implement dynamic panel scaling, scale at .16 for every digit present in number

	// Use this for initialization
	void Awake () {

		scoreText = GetComponent<Text>();
		numDigits = 0;
		colorText = transform.parent.GetChild(0).GetComponent<Text>();
		if(playScoreCounter) {
			updateScore(0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//update and fix places if needed
	public void updateScore(int score) {
		//set new score text
		scoreText.text = score.ToString();

		//check length to see if we need to scale panel
		int length = score.ToString().Length;
		if (length > numDigits) {
			numDigits = length;
		}

		//now update the color text above

		//use string holder
		string s = "";
		for (int i = 0; i < length; i++){
			s += "_";
		}
		colorText.text = s;
	}
}
