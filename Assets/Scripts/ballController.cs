using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballController : MonoBehaviour {
	
	//ui score text
	public Text scoreText;

	//the thing that spawns the gates
	public gateSpawner gateSpawner;

	//previously used for my sprite animations
	public Sprite[] frames;

	//frames for animation
    public float framesPerSecond = 5;

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
		score++;
		scoreText.text = score.ToString();
		//every 10 gates passed, create ten more gates
		if (score % 10 == 0) {
			gateSpawner.createGates();
		}
	}

	public void loseAnimation() {
		//turn off the sprites that represent the ball
		transform.GetChild(0).gameObject.SetActive(false);
		transform.GetChild(1).gameObject.SetActive(false);
		ballSprite.enabled = false;

		//activate particles to be "pieces" of the ball
		particleHolder.SetActive(true);
		foreach (Transform child in particleHolder.transform){
			//explode them
			child.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)) * explosionForce);
		}
		// StartCoroutine(PlayAnimation());
	}

	IEnumerator PlayAnimation()
    {
        // int currentFrameIndex = 0;
        // while (true) {
        //     spriteRenderer.sprite = frames [currentFrameIndex];
		// 	yield return new WaitForSeconds(.05f);
        //      // this halts the functions execution for x seconds. Can only be used in coroutines.
		// 	currentFrameIndex++;
        // }

		
		for (int i = 0; i < frames.Length; i++){
			ballSprite.sprite = frames[i];
			yield return new WaitForSeconds(.05f);
		}
    }
}
