using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class uiManager : MonoBehaviour {

	public Text scoreText;
	public Button[] buttons;
	public Button pauseButton;
	public AudioManager am;
	public bool gameOver, flagPause;
	public static int score;

	// Use this for initialization
	void Start () {
		gameOver = false;
		flagPause = false;
		score = 0;
		InvokeRepeating ("scoreUpdate", 1.0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevel == 1) {
			scoreText.text = "Score: " + score;
		}
	}

	void scoreUpdate() {
		if (!gameOver) {
			score += 1;
		}
	}

	public void gameOverActivated() {
		gameOver = true;
		foreach (Button button in buttons) {
			button.gameObject.SetActive(true);
		}
        //Reset();
	}

	public void play() {
        //Reset();
        Application.LoadLevel ("Level1");
	}

    public void StartPlaying()
    {
        //Reset();
        Application.LoadLevel("Level1");
    }

    // Resets the speed.
    //public void Reset()
    //{
    //    trackMove.speed = .2f;
    //    EnemyCarMove.speed = 3f;
    //    //carSpawner.delayTimer = .2f;
    //}

    public void Pause() {
		if (Time.timeScale == 1) {
			Time.timeScale = 0;
			am.carSound.Stop ();
			flagPause = true;
			pauseButton.GetComponentInChildren<Text>().text = ">";
		} else if (Time.timeScale == 0) {
			Time.timeScale = 1;
			if (!gameOver) {
				am.carSound.Play ();
			}
			flagPause = false;
			pauseButton.GetComponentInChildren<Text>().text = "| |";
		}
	}

	/** public void Replay() {
		Application.LoadLevel (Application.loadedLevel);
	} */

	public void Menu() {
		Application.LoadLevel (name: "Menu");
	}

	public void Exit() {
		Application.Quit ();
	}
}
