using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 5f;
	public float padding = 0.5f;

	private float X_MIN = 0;
	private float X_MAX = 0;

	private Vector3 POSITION { get { return this.GetComponent<Transform>().position; }}

	private void Start() {

		float distance = POSITION.z - Camera.main.GetComponent<Transform>().position.z;
		var leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		var rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));

		X_MIN = leftMost.x + padding;
		X_MAX = rightMost.x - padding;
	}

	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey(KeyCode.LeftArrow)) {
			this.GetComponent<Transform>().Translate((Vector3.left * speed) * Time.deltaTime );
		}
		
		if (Input.GetKey(KeyCode.RightArrow)) {
			this.GetComponent<Transform>().Translate((Vector3.right * speed) * Time.deltaTime);
		}

		float newX = Mathf.Clamp(this.GetComponent<Transform>().position.x, X_MIN, X_MAX);
		this.GetComponent<Transform>().position = new Vector3 (newX, POSITION.y, POSITION.z);

	}
}
