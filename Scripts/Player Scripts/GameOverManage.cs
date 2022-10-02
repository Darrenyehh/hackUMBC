using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManage : MonoBehaviour
{
    Timer gameTime;
    public TextMeshProUGUI score;
    public bool winOrLose = false;
    public GameObject blueImage, win, lose;
    public ChipMovemnt chpMove;
    bool gameEnded = false;
    private void Start()
    {
        gameTime = FindObjectOfType<Timer>();
    }
    public void GameEnd()
    {
        chpMove.hasTime = false;
        blueImage.SetActive(true);
        gameEnded = true;
        chpMove.rb.velocity = Vector2.zero;
        if (winOrLose)
        {
            int timez = (int)gameTime.totalTime;
            win.SetActive(true);
            score.text = "Score: " + timez.ToString();
        }
        else
        {
            lose.SetActive(true);
        }
    }
    private void Update()
    {
        if (gameEnded && Input.GetMouseButton(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
