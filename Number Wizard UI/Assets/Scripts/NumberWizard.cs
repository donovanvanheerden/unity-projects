using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {

	public Text txtGuess;

	int MAX, MIN, GUESS;
	public int MAX_GUESSES_ALLOWED = 5;

	void Start () {
		StartGame();
	}

	void StartGame() {
		MAX = 1000; MIN = 1;
		NextGuess();
	}

	public void GuessHigher() {
		MIN = GUESS;
		NextGuess();
	}

	public void GuessLower() {
		MAX = GUESS;
		NextGuess();
	}

	void NextGuess() {
		MAX_GUESSES_ALLOWED -= 1;
		
		if (MAX_GUESSES_ALLOWED < 0) {
			SceneManager.LoadScene("Win");
			return;
		}

		GUESS = System.Convert.ToInt32(UnityEngine.Random.Range(MIN, MAX + 1));
		txtGuess.text = GUESS.ToString();
	}

}
