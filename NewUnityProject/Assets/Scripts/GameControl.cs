using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    public static GameControl instance;
    public int lifes = 3;
	public int health = 3;

    public bool music = true;

    private int points = 0;

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

    public  int getPoints()
    {
        return points;
    }

	public void DiePlayer(Text Button){
		health--;
		Button.text = "x" + health.ToString();

		if (health == 0) {
            LifeUp (3);
			LoadScene ("GameOver");
		}
	}

	public void LoadScene (string SceneName){
		SceneManager.LoadScene (SceneName);
	}
    public void LifeUp(int healthAdd){
        health += healthAdd;
	}

    public void takeDamage()
    {
        lifes--;
	}

	public void getLife(int lifeadd)
    {
		lifes += lifeadd;
    }

}
