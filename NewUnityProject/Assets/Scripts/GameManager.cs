using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public void LoadScene (string SceneName)
	{
		SceneManager.LoadScene (SceneName);
	}
	public void Quit()
	{

		Application.Quit ();
	}

}
