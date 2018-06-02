using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private bool gameStarted = false;
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (!gameStarted) 
			// Lock ball relative to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;

		// wait for mouse click before starting the game
		if (!gameStarted && Input.GetMouseButtonDown(0)) {
			gameStarted = true;

			this.GetComponent<Rigidbody2D>().velocity = new Vector2(3f, 10f);
		}
	}

	private void OnCollisionEnter2D(Collision2D other) {

		if (gameStarted) { 

			Vector2 tweak = new Vector2(Random.Range(0f, 0.5f), Random.Range(0f, 0.5f));

			this.GetComponent<Rigidbody2D>().velocity += tweak;
			this.GetComponent<AudioSource>().Play();
		}
	}
}
