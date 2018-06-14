using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballController : MonoBehaviour {
	
	public Text scoreText;

	public gateSpawner gateSpawner;

	public Sprite[] frames;

    public float framesPerSecond = 5;

	private int score = 0;

	SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void updateScore() {
		score++;
		scoreText.text = score.ToString();
		if (score % 10 == 0) {
			gateSpawner.createGates();
		}
	}

	public void loseAnimation() {
		transform.GetChild(0).gameObject.SetActive(false);
		StartCoroutine(PlayAnimation());
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
			spriteRenderer.sprite = frames[i];
			yield return new WaitForSeconds(.05f);
		}
    }
}
