using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour {	

	public void LoadScene (string SceneName)
	{
		SceneManager.LoadScene (SceneName);
	}
}
