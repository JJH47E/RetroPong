using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opponentMovement : MonoBehaviour
{
    private Vector2 up_vel, down_vel;
    public Transform ball;
    public Transform enemy;
    private bool moveDown, moveUp;
    public Rigidbody2D rb;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = PlayerPrefs.GetFloat("playerMove") * 0.35f;
        up_vel = new Vector2(0, speed);
        down_vel = new Vector2(0, -speed);
        moveDown = false;
        moveUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.position[1] > ball.position[1])
        {
            moveDown = true;
            moveUp = false;
        }
        else
        {
            moveDown = false;
            moveUp = true;
        }
    }

    void FixedUpdate()
    {
        if(moveDown == true)
        {
            rb.velocity = down_vel;
        }
        if(moveUp == true)
        {
            rb.velocity = up_vel;
        }
    }
}
