using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreController : MonoBehaviour {


	public Sprite[] numberSprites;
	private Image onesPlace;
	private Image tensPlace;
	private Image[] numberSpots;

	// Use this for initialization
	void Start () {
		//get the boi and get its digit places
		onesPlace = transform.GetChild(0).GetComponent<Image>();
		tensPlace = transform.GetChild(1).GetComponent<Image>();

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

	//maybe use in future
	//this would mean update score would do something like shifting the number spots around to not show all 6 digits at once
	//and then this funciton would actually set the sprite images
	public void changeNumbers(int score) {

	}
}
