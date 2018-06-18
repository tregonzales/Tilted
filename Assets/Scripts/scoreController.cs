using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreController : MonoBehaviour {


	public Sprite[] numberSprites;
	private Image[] numberSpots;

	// Use this for initialization
	void Awake () {

		numberSpots = new Image[6];
		//get all the children images of all number spots starting with ones place
		for (int i = 0; i < transform.childCount; i++){
			numberSpots[i] = transform.GetChild(i).GetComponent<Image>();
		}
		updateScore(0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//update and fix places if needed
	public void updateScore(int score) {
		//set the digits
		numberSpots[0].sprite = numberSprites[score % 10];
		// numberSpots[1].sprite = numberSprites[score / 10];
		for (int i = 1; i < numberSpots.Length; i++){
			numberSpots[i].sprite = numberSprites[(int)(score / Mathf.Pow(10, i)) % 10];
		}
	}

	public void shift(int score) {
		//use this function to shift the anchors and only set certain digits to active to only see
		//digits that hold real value
		//implement later
	}
}
