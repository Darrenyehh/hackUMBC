using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI[] gameTimer;
    public float totalTime;//seconds
    public ChipMovemnt chpMove;
    GameOverManage gmMan;
    void Start()
    {
        totalTime *= 15;
        gmMan = FindObjectOfType<GameOverManage>();
    }

    // Update is called once per frame
    void Update()
    {
        runTimer();
    }
    private void formatTimer()
    {//for the top right
        //gets the seconds and mins
        float minutes = Mathf.FloorToInt(totalTime / 60);
        float seconds = Mathf.FloorToInt(totalTime % 60);

        string currentTime = seconds > 9 ? minutes + "" + seconds :
            minutes + "0" + seconds;
        for (int i = 0; i < gameTimer.Length; i++)
        {
            if(i == 0)
               gameTimer[i].text = currentTime[i].ToString() + ":";
            else
                gameTimer[i].text = currentTime[i].ToString();
        }
    }
    private void runTimer()
    {//actually runs the timer
        if (!gmMan.winOrLose)
        {
            if (totalTime > 15)
                totalTime -= Time.deltaTime;
            else if (totalTime < 15 && totalTime > 0)
            {
                for (int i = 0; i < gameTimer.Length; i++)
                {
                    gameTimer[i].color = Color.red;
                }
                totalTime -= Time.deltaTime;
            }
            else
            {
                totalTime = 0;
                gmMan.winOrLose = false;
                gmMan.GameEnd();
            }
        }
        formatTimer();
    }
}
