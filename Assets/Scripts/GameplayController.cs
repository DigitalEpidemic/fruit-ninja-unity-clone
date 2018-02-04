using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour {

	public static GameplayController instance;

	public Text countDownText, scoreText;
	public float countDownTimer = 3.0f;
	public bool hasLevelStarted;

	public int playerScore;

	void Awake () {
		CreateInstance ();
	}

	void Start () {
		InitializeGameplayController ();
		hasLevelStarted = true;
	}

	void Update () {
		UpdateGameplayController ();
	}

	void CreateInstance () {
		if (instance == null) {
			instance = this;
		}
	}

	void InitializeGameplayController () {
		Time.timeScale = 0;
		countDownText.text = countDownTimer.ToString ("F0");

		playerScore = 0;
		scoreText.text = "" + playerScore;
	}

	void UpdateGameplayController () {
		scoreText.text = "" + playerScore;
		if (hasLevelStarted) {
			CountDownAndBeginLevel ();
		}
	}

	void CountDownAndBeginLevel () {
		countDownTimer -= (0.19f * 0.15f);
		countDownText.text = countDownTimer.ToString ("F0");

		if (countDownTimer <= 0) {
			Time.timeScale = 1;
			hasLevelStarted = false;
			countDownText.gameObject.SetActive (false);
		}
	}

} // GameplayController