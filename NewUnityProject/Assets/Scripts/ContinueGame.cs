using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueGame : MonoBehaviour {

	void Update () {
		if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.JoystickButton10)){
			LoadScene ("MainMenu");	
	}
}
		public void LoadScene (string SceneName){
			SceneManager.LoadScene (SceneName);
	}
}