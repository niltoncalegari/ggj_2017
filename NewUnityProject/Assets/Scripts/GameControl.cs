using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    public static GameControl instance;
    public int lifes = 3;
    public int points = 0;
	public int health = 3;
    public bool music = true;


    void Awake () {
        if (instance == null) {
            DontDestroyOnLoad (gameObject);
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }
	public void addPoints(int pointsAdd)
    {
        points += pointsAdd;
    }

    public void removePoints(int pointsRemove)
    {
        points -= pointsRemove;
    }
	public void DiePlayer(Text Button){
		health--;
		Button.text = "x" + health.ToString();
		if (health == 0) {
			LoadScene ("GameOver");
		}
	}
	public void LoadScene (string SceneName){
		SceneManager.LoadScene (SceneName);
	}
	public void LifeUp(){
		health++;
	}
    public void takeDamage()
    {
        lifes--;
	}
	public void getLife(int lifeadd)
    {
		lifes = lifeadd;
    }

}
