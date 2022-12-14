using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    int stage = 0;//we want u to see the how to play screen then click again to bring u into the game
    public Canvas one,two;
    public TextMeshProUGUI hscore;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            changeCanvas();
        }
        checkHighScore();
    }
    private void changeCanvas()
    {//changes canvas or level
        if (stage == 0)
        {
            one.enabled = false;
            two.enabled = true;
            stage++;
        }
    }
    void checkHighScore()
    {//checks if the highscore is not 0
        Debug.Log(GameManager.game.highscore);
        if(GameManager.game.highscore != 0)
        {
            hscore.text = "HighScore:" + GameManager.game.highscore;
        }
    }
    public void setHard(bool b)
    {
        GameManager.game.hardMode = b;
    }
    public void Level()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
