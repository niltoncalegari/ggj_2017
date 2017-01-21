using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    public static GameControl instance;
    public int lifes = 3;
    public int points = 0;
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

    public void takeDamage()
    {
        lifes--;
    }

    public void getLife()
    {
        lifes++;
    }

}
