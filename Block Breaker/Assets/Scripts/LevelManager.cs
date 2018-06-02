using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

// MUSIC FROM https://freesound.org/people/joshuaempyre/sounds/251461/?page=2#
public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		Brick.ResetCount();
		SceneManager.LoadScene(name);
	}

	public void QuitRequest(){
		Application.Quit();
	}

	public void LoadNextLevel() {
		var scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.buildIndex + 1);
	}

	public void BrickDestroyed() {
		if (Brick.breakableCount <= 0) { 
			Brick.ResetCount();
			LoadNextLevel(); 
		}
	}

}
