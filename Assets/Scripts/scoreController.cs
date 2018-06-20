using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreController : MonoBehaviour {


	Text scoreText;
	public bool playScoreCounter;
	private RectTransform panelRectTrans;
	private int numDigits;

	//implement dynamic panel scaling, scale at .16 for every digit present in number

	// Use this for initialization
	void Awake () {

		scoreText = GetComponent<Text>();
		numDigits = 0;
		panelRectTrans = transform.parent.GetChild(0).GetComponent<RectTransform>();
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
			shift(length);
		}
	}

	public void shift(int length) {
		Vector3 temp = panelRectTrans.localScale;
		temp.x = .16f * length;
		panelRectTrans.localScale = temp;
	}
}
