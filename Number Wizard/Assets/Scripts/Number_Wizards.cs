using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number_Wizards : MonoBehaviour {

	int MAX, MIN, GUESS;

	// Use this for initialization
	void Start () {
		StartGame();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			MIN = GUESS;
			NextGuess();
		} else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			MAX = GUESS;
			NextGuess();
		} else if (Input.GetKeyDown(KeyCode.Return)) {
			print("I WON!\r\n");
			StartGame();
		}
	}

	void StartGame() {
		MAX = 1000; MIN = 1;
		
		print("\r\n============================================");
		print("Welcome to Number Wizard\r\nPick a number in your head, but don't tell me!");
		print("The highest number you can pick is " + MAX + 
			"\r\nThe lowest number you can pick is " + MIN);

		NextGuess();
		
		// Fix Rounding Down Issue.
		MAX += 1;
	}

	void NextGuess() {
		GUESS = (MAX + MIN) / 2;
		print("Is the number higher or lower than " + GUESS + "?\r\n");
		
		print("Up = Higher\r\nDown = Lower"); 
		print("Return = Equal.\r\n");
	}

}
