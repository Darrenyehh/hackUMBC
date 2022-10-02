using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentEmoji : MonoBehaviour
{
    [SerializeField]Sprite[] sprites;//holds the emojis
    public SpriteRenderer sp;
    public bool isMakingFace = false;
    private float timer;
    public void makeFace()
    { // selects a random emoji
            int random = UnityEngine.Random.Range(0, sprites.Length);
            sp.sprite = sprites[random];
    }
    private void Update()
    { //deactivates the emoji
        if (isMakingFace)
        {
            timer += Time.deltaTime;
            if(timer > 1f)
            {
                isMakingFace = false;
            }
        }
        else
        {
            sp.sprite = null;
        }
    }
}
