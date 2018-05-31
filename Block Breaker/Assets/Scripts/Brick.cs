using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public int maxHits;
	private int timesHit;
	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionExit2D(Collision2D other) {
		timesHit++;	

		if (maxHits != 0 && timesHit >= maxHits)
			Destroy(gameObject);

		//SimulateWin();
	}

	// TODO: Remove SimulateWin
	private void SimulateWin() {
		levelManager.LoadNextLevel();
	}
}
