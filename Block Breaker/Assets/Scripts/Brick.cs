using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public static int breakableCount { get; private set; }
	public AudioClip crack;
	public Sprite[] hitSprites;
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;
	// Use this for initialization
	void Start () {
		timesHit = 0;
		
		isBreakable = (tag == "Breakable");

		if (isBreakable) breakableCount++;
		
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	private void HandleHit () {
		timesHit++;	

		int maxHits = hitSprites.Length + 1;

		if (maxHits != 0 && timesHit >= maxHits) {
			breakableCount--;
			Destroy(gameObject);
			levelManager.BrickDestroyed();
		}
		else {
			AudioSource.PlayClipAtPoint(crack, transform.position);
			LoadSprite();
		}
			
	}

	public static void ResetCount() {
		breakableCount = 0;
	}

	private void OnCollisionExit2D(Collision2D other) {
		if (isBreakable) HandleHit();
	}

	private void LoadSprite() {
		// Check if sprite exists at index, otherwise don't attempt to load sprite
		if (hitSprites[timesHit - 1] != null) 
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit - 1];
		else 
			Debug.LogError("Missing Brick Sprite");
	}
}
