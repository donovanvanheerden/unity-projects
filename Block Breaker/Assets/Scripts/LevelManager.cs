using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

// MUSIC FROM https://freesound.org/people/joshuaempyre/sounds/251461/?page=2#
public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		SceneManager.LoadScene(name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit();
	}

}
