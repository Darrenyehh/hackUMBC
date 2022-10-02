using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestinationManager : MonoBehaviour
{
    public GameObject[] buildings;
    public StudentManager stMan; //this is useless as of rn
    [SerializeField]TextMeshProUGUI text;
    private int lastBuilding = -1, random = -1; // so u dont get the same building twice
    public GameObject currentTask;

    void Start()
    {
        buildings = GameObject.FindGameObjectsWithTag("Doors");
        setCurrentTask();
    }
    public void setCurrentTask()
    {//sets the current building we gots to go to, we want it to not use the same building twice in a row
        while (lastBuilding == random)
        {
            random = UnityEngine.Random.Range(0, buildings.Length);
            if (random != lastBuilding)
            {
                var temp = buildings[random].GetComponent<DestinationScript>();
                currentTask = buildings[random];
                temp.isCurrentObj = true;
                text.text = temp.buildingName;
            }
        }
        lastBuilding = random;

    }
}
