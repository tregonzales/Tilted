using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballController : MonoBehaviour {
	
	//the thing tilting this object
	public tilterController tilter;

	//ui score text
	public scoreController scoreController;

	//the thing that spawns the gates
	public gateSpawner gateSpawner;

	//keeps track of universal score
	private int score = 0;

	//sprite of this object
	SpriteRenderer ballSprite;

	//holds the particles that are in the current losing explosion animation
	private GameObject particleHolder;

	//how much for to explode with
	public float explosionForce;

	// Use this for initialization
	void Start () {
		ballSprite = GetComponent<SpriteRenderer>();
		particleHolder = transform.GetChild(2).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void updateScore() {
		//every 10 gates passed, create ten more gates
		score++;
		if (score % 10 == 0) {
			gateSpawner.createGates();
		}
		scoreController.updateScore(score);
	}

	public void loseAnimation() {
		//turn off the sprites that represent the ball and stop motion
		tilter.loseAnimation();
		transform.GetChild(0).gameObject.SetActive(false);
		transform.GetChild(1).gameObject.SetActive(false);
		ballSprite.enabled = false;

		//activate particles to be "pieces" of the ball
		particleHolder.SetActive(true);
		foreach (Transform child in particleHolder.transform){
			//explode them
			child.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)) * explosionForce);
		}
		StartCoroutine(promptEndGame());
	}

	IEnumerator promptEndGame() {
		yield return new WaitForSeconds(1f);
		GameManager.instance.ToggleLoseGame();
	}
}
