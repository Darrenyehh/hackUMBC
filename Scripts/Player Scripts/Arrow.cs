using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{//makes the arrow that points to the direction of the thingy
    public Transform Chip, Target;
    public DestinationManager dMan;
    public SpriteRenderer sp;
    private void Awake()
    {
        if (GameManager.game.hardMode)
        {
            sp.sprite = null;
        }
    }
    private void Update()
    {
        grabTarget();
    }
    private void grabTarget()
    {//grabs the target
        Target = dMan.currentTask.transform;
        pointArrow();
    }
    private void pointArrow()
    {//points towards the target
        Vector3 rotation = Target.position - Chip.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg; //gets the degrees for the z
        transform.localRotation = Quaternion.Euler(0, 0, rotZ);
    }
}
