using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	const float minX = 0.5f;
	const float maxX = 15.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 paddlePos = new Vector3(CalculateX(), this.transform.position.y, 0f);

		this.transform.position = paddlePos;
	}

	float CalculateX() {
		// Single Game Unit = 16. Therefore relative position in window.
		var X = Input.mousePosition.x / Screen.width * 16;

		return Mathf.Clamp(X, minX, maxX);
	}
}
