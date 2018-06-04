using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	
	public float speed = 0.5f;
	public float padding = 0.5f;
	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	private bool movingRight = true;

	private float X_MIN = 0;
	private float X_MAX = 0;

	// Use this for initialization
	void Start () {

		float distance = this.GetComponent<Transform>().position.z - Camera.main.GetComponent<Transform>().position.z;
		var leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		var rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));

		X_MIN = leftBoundary.x;
		X_MAX = rightBoundary.x;

		foreach (Transform t in this.GetComponent<Transform>()) {
			var enemy = Instantiate(enemyPrefab, new Vector3(t.position.x, t.position.y,5), Quaternion.identity);
			enemy.GetComponent<Transform>().parent = t;
		}

	}
	
	private void OnDrawGizmos() {
		Gizmos.DrawWireCube(this.GetComponent<Transform>().position, new Vector3(width, height, 0));
	}

	private void Update() {
		
		this.GetComponent<Transform>().Translate(((movingRight ? Vector3.right : Vector3.left) * speed / 2f) * Time.deltaTime);

		float rightEdgeOfFormation = this.GetComponent<Transform>().position.x + (0.5f * width);
		float leftEdgeOfFormation = this.GetComponent<Transform>().position.x - (0.5f * width);

		if (leftEdgeOfFormation < X_MIN) {
			movingRight = true;
		} else if (rightEdgeOfFormation > X_MAX) {
			movingRight = false;
		}
	}

}
