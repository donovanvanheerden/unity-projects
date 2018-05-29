using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	private static MusicPlayer _instance;

	public static MusicPlayer instance 
  {
		get {
			if (_instance == null) {
				_instance = GameObject.FindObjectOfType<MusicPlayer>();
			}

			return _instance;
		}
	}

	// Use this for initialization
	void Awake () {
		if (_instance != null && _instance != this) {
			Destroy(this.gameObject);
		} else {
			_instance = this;
			GameObject.DontDestroyOnLoad(_instance);
		}
	}
	
}
