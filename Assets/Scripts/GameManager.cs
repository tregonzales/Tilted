using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour {

	//thats me, everywhere all at once
	public static GameManager instance;

	//current ui system
	public GameObject currentUI;

	//is we paused
	public bool paused;
	
	//are we in main menu
	public bool mainMenu;

	//pretty self explanatory
	public GameObject pauseButton;

	//this is just the resume button but whatever
	public GameObject resumeButton;

	//choices after losing
	public GameObject postGameOptions;

	//post game this score text and panel
	public GameObject thisScore;

	//post game best score text and panel
	public GameObject bestScore;

	//the big object holding it all for post game score info
	public GameObject highScoreInfo;

	//top screen counter while playing
	public GameObject playScoreCounter;

	//how many times to play before you hit an ad
	public int playsBeforeAd;

	void Start () {
		instance = this;
		if (!mainMenu) {
			paused = false;
			Time.timeScale = 1.0f;
			pauseButton.SetActive(!paused);
			resumeButton.SetActive(paused);
			int curPlays = PlayerPrefs.GetInt("plays");
			curPlays++;
			PlayerPrefs.SetInt("plays", curPlays);
		}
		else {
			// paused = true;	
		}
	}
	
	void Update () {

	}

	public void scaleUI() {
		//scale camera to pixel sizes to always fit
		currentUI.GetComponent<CanvasScaler>().referenceResolution =
		new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight);
	}

	public void setHighSchore(int score) {
		if (score > PlayerPrefs.GetInt("highScore")) {
			//for now test using regular high score
			highScoreInfo.SetActive(true);
			//new high score!
			PlayerPrefs.SetInt("highScore", score);
			thisScore.GetComponent<scoreController>().updateScore(score);
			bestScore.GetComponent<scoreController>().updateScore(score);
		}
		else {
			//same score, so usually do this
			highScoreInfo.SetActive(true);
			thisScore.GetComponent<scoreController>().updateScore(score);
			bestScore.GetComponent<scoreController>().updateScore(PlayerPrefs.GetInt("highScore"));
		}
	}

	public void adCheck(bool restart) {
		string nextScene = restart ? SceneManager.GetActiveScene().name : "mainMenu";
		postGameOptions.SetActive(false);
		int curPlays = PlayerPrefs.GetInt("plays");
		if (curPlays >= playsBeforeAd) {
			if (Advertisement.IsReady("video")) {
				Advertisement.Show("video");
				PlayerPrefs.SetInt("plays", 0);
				StartCoroutine(WaitForAd(nextScene));
			}
			else {
				LoadScene(.5f, nextScene);
			}
		}
		else {
			// curPlays++;
			// PlayerPrefs.SetInt("plays", curPlays);
			LoadScene(.5f, nextScene);
		}
	}

	IEnumerator WaitForAd(string sceneAfter) {
		while (Advertisement.isShowing) {
			yield return null;
		}
		LoadScene(.5f, sceneAfter);
	}
		
	public void RestartTheGameAfterSeconds(float seconds){
		Time.timeScale = 1.0f;
		StartCoroutine (LoadSceneAfterSeconds (seconds, SceneManager.GetActiveScene().name));
	}

	public void LoadScene(float seconds, string sceneName){
		Time.timeScale = 1.0f;
		StartCoroutine (LoadSceneAfterSeconds (seconds, sceneName));
	}

	public void LoadSceneByName(string sceneName) {
		SceneManager.LoadScene(sceneName);
	}

	public void LoadSceneByIndex(int i){
		SceneManager.LoadScene(i);
	}

	public void LoadMainMenu() {
		SceneManager.LoadScene("mainMenu");
	}

	public void LoadNextScene(float seconds) {
		StartCoroutine (LoadSceneAfterSeconds (seconds, null));
	}
	
	public void ToggleLoseGame(int score) {
		Debug.Log("ya lost");
		playScoreCounter.SetActive(false);
		pauseButton.SetActive(false);
		postGameOptions.SetActive(true);
		setHighSchore(score);
		Time.timeScale = 0f;
    }

	public void TogglePause() {
		if (paused)
        {
			pauseButton.SetActive(paused);
            resumeButton.SetActive(!paused);
            Time.timeScale = 1.0f;
        }
        else
        {
			pauseButton.SetActive(paused);
            resumeButton.SetActive(!paused);
            Time.timeScale = 0f;
        }
        paused = !paused;
    }

	IEnumerator LoadSceneAfterSeconds(float seconds, string sceneName){
		yield return new WaitForSeconds (seconds);
		if (sceneName == null) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
		}
		else {
			SceneManager.LoadScene (sceneName);
		}
	}
}