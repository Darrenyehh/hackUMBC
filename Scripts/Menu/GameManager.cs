using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager game;
    public int highscore = 0;
    public bool hardMode = false;
    GameOverManage gameOver;
    void Awake()
    {//creates a singleton of the gamemanager
        if (GameManager.game != null)
        {
            Destroy(gameObject);
            return;
        }
        game = this;
        DontDestroyOnLoad(gameObject);
    }
    
    public void trackScore(int score)
    {
        if(score > highscore)
        {
            highscore = score;
        }
    }
}
