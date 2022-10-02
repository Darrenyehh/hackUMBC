using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationScript : MonoBehaviour
{
    public string buildingName;
    private StudentManager stuMan;
    private DestinationManager dMan;
    public bool isCurrentObj = false;
    GameOverManage gmManl;
    private void Start()
    {
        stuMan = GameObject.FindGameObjectWithTag("GameController").GetComponent<StudentManager>();
        dMan = GetComponentInParent<DestinationManager>();
        gmManl = FindObjectOfType<GameOverManage>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {//remove student
        if (collision.gameObject.CompareTag("Player") && isCurrentObj)
        {//sees if chip reacches the door
            checkIfGameOver();
            stuMan.students[stuMan.minIndex].SetActive(false);
            stuMan.minIndex++;
            stuMan.setTransform();
            isCurrentObj = false;
            dMan.setCurrentTask();
        }
    }
    private void checkIfGameOver()
    {//checks if chip won
        if(stuMan.minIndex == stuMan.students.Length - 1)
        {
            Debug.Log("u won");
            gmManl.winOrLose = true;
            gmManl.GameEnd();
        }
    }
}
