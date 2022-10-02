using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentManager : MonoBehaviour
{
    public GameObject[] students;
    private Transform playerTrans, pStuTrans;
    public int minIndex = 0;
    public DestinationManager dMan;
    private float timer;
    private void Start()
    {
        students = GameObject.FindGameObjectsWithTag("Student");
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        setTransform();
    }
    public void setTransform()
    {//sets the follow transform of the students
        for (int i = 0; i < students.Length; i++)
        {
            var tempFollow = students[i].GetComponent<StudentFollow>();
            if(i == minIndex) 
            {
                tempFollow.followTrans = playerTrans;
                pStuTrans = tempFollow.transform;
            }
            else if(i > minIndex)
            {
                tempFollow.followTrans = pStuTrans;
                pStuTrans = tempFollow.transform;
            }
        }
    }
    private void Update()
    {
        setEmoji();
    }
    public void setEmoji()
    {//sets the emoji of a random student
        timer += Time.deltaTime;
        if(timer > 2)
        {
            int random = Random.Range(0, students.Length);
            var temp = students[random].GetComponent<StudentEmoji>();
            temp.isMakingFace = true;
            temp.makeFace();
            timer = 0f;
        }
    }
}
