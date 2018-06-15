using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public bool paused;
	public bool mainMenu;
	public GameObject pauseButton;
	//this is just the resume button but whatever
	public GameObject pauseMenu;

	void Start () {
		instance = this;
		if (!mainMenu) {
			paused = false;
			Time.timeScale = 1.0f;
			pauseButton.SetActive(!paused);
			pauseMenu.SetActive(paused);
		}
		else {
			// paused = true;	
		}
	}
	
	void Update () {

	}
		
	public void RestartTheGameAfterSeconds(float seconds){
		Time.timeScale = 1.0f;
		StartCoroutine (LoadSceneAfterSeconds (seconds, SceneManager.GetActiveScene ().name));
	}

	public void LoadScene(float seconds, string sceneName){
		StartCoroutine (LoadSceneAfterSeconds (seconds, sceneName));
	}

	public void LoadSceneByIndex(int i){
		SceneManager.LoadScene(i);
	}

	public void LoadMainMenu() {
		SceneManager.LoadScene("Main_Menu");
	}

	public void LoadNextScene(float seconds) {
		StartCoroutine (LoadSceneAfterSeconds (seconds, null));
	}
	
	public void ToggleLoseGame() {
		Debug.Log("ya lost");
		Time.timeScale = 0f;
    }

	public void TogglePauseMenu() {
		if (paused)
        {
			pauseButton.SetActive(paused);
            pauseMenu.SetActive(!paused);
            Time.timeScale = 1.0f;
        }
        else
        {
			pauseButton.SetActive(paused);
            pauseMenu.SetActive(!paused);
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