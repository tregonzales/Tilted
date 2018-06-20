using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public bool paused;
	public bool mainMenu;
	public GameObject pauseButton;
	//this is just the resume button but whatever
	public GameObject resumeButton;
	public GameObject postGameOptions;
	public GameObject thisScore;
	public GameObject bestScore;
	public GameObject highScoreInfo;
	public GameObject playScoreCounter;

	void Start () {
		instance = this;
		if (!mainMenu) {
			paused = false;
			Time.timeScale = 1.0f;
			pauseButton.SetActive(!paused);
			resumeButton.SetActive(paused);
		}
		else {
			// paused = true;	
		}
	}
	
	void Update () {

	}

	public void adShow() {
		
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
		
	public void RestartTheGameAfterSeconds(float seconds){
		Time.timeScale = 1.0f;
		StartCoroutine (LoadSceneAfterSeconds (seconds, SceneManager.GetActiveScene().name));
	}

	public void LoadScene(float seconds, string sceneName){
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