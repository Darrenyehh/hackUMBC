using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipMovemnt : MonoBehaviour
{//for movement but im doubling it as animations
    public Rigidbody2D rb;
    [SerializeField] private float walkSpeed = 5f;
    private Vector2 movement;
    public bool hasTime = true;
    private SpriteRenderer sp;
    private Animator anim;
    private void Start()
    {//grabs the rigidBody
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(hasTime)
        Move();
        animations();
    }
    private void Move()
    {//wasd arrow keys to move
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
        rb.velocity = movement * walkSpeed;
    }
    private void animations()
    {
        if(rb.velocity.x > .1f || rb.velocity.x < -.1f)
        {
            anim.SetInteger("movement", 1);
            sp.flipX = rb.velocity.x < .1f ? true : false;
        }
        else if(rb.velocity.y > .1f)
        {
            anim.SetInteger("movement", 2);
        }
        else if (rb.velocity.y < -.1f)
        {
            anim.SetInteger("movement", 3);
        }
        else
        {
            anim.SetInteger("movement", 0);
        }
    }
}
