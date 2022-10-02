using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentFollow : MonoBehaviour
{
    public Transform followTrans;
    private Transform trans;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float furthestDistance = 0;
    Vector3 distance;
    bool up, down, right, left; // to know if the student is stuck on a wall
    [SerializeField] private LayerMask walls;
    private RaycastHit2D north, south, east, west;
    private SpriteRenderer sp;
    private Animator anim;

    private void Start()
    {//get the trans
        trans = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    private void createRays()
    {// creates rays that are in each direction to test if they are touching a wall
        north = Physics2D.Raycast(transform.position, Vector2.up, .75f, walls);
        up = north;
        south = Physics2D.Raycast(transform.position, Vector2.down, .75f, walls);
        down = south;
        east = Physics2D.Raycast(transform.position, Vector2.right, .75f, walls);
        right = east;
        west = Physics2D.Raycast(transform.position, Vector2.left, .75f, walls);
        left = west;
    }
    private void Update()
    {
        follow();
        animations();
    }
    private void follow()
    {//checks if chip(or another student) is far away enough to start following
        distance = trans.position - followTrans.position;
        //checks if the x or y is a negative number
        float x = distance.x < 0 ? distance.x * -1 : distance.x;
        float y = distance.y < 0 ? distance.y * -1 : distance.y;
        float distanceTotal = x + y;
        createRays();
        if(distanceTotal > furthestDistance)
        {
            movement = distance.normalized;
            rb.velocity = movement * -10f;
            if (up)
                stuckOnWall(Vector2.up, movement);
            else if (right)
                stuckOnWall(Vector2.right, movement);
            else if (left)
                stuckOnWall(Vector2.left, movement);
            else if (down)
                stuckOnWall(Vector2.down, movement);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
    private void stuckOnWall(Vector2 direction, Vector2 movement)
    { // makes the students less likely to get stuck onto walls
        switch (direction) 
        {
            case Vector2 v when v.Equals(Vector2.up):
                if (movement.y < 0)
                    movement.y = 0;
                movement = movement.normalized;
                rb.velocity = movement * -10f;
                break;
            case Vector2 v when v.Equals(Vector2.down):
                if (movement.y > 0)
                    movement.y = 0;
                movement = movement.normalized;
                rb.velocity = movement * -10f;
                break;
            case Vector2 v when v.Equals(Vector2.right):
                if (movement.x < 0)
                    movement.x = 0;
                movement = movement.normalized;
                rb.velocity = movement * -10f;
                break;
            case Vector2 v when v.Equals(Vector2.left):
                if (movement.x > 0)
                    movement.x = 0;
                movement = movement.normalized;
                rb.velocity = movement * -10f;
                break;
        }
    }
    private void animations()
    {
        if (rb.velocity.x != 0)
        {
            sp.flipX = rb.velocity.x < .1f ? true : false;
            anim.SetBool("movin", true);
        }
        else
            anim.SetBool("movin", false);

    }
}
