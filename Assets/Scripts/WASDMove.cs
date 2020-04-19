using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDMove : MonoBehaviour
{
    public static int moveSpeed = 9;
    public int moveSpeedDisplay = moveSpeed;
    public Rigidbody2D florist;
    public Animator animator;
    Vector2 movement;
    Vector2 facing;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Sets the values of the parameters in the animator so that animations match character movement
        animator.SetFloat("horMove", movement.x);
        animator.SetFloat("vertMove", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);

        //Character position for when they are not moving
        if(movement.x != 0 || movement.y != 0)
        {
            facing = movement;
        }
        animator.SetFloat("horFace", facing.x);
        animator.SetFloat("vertFace", facing.y);
    }

    void FixedUpdate()
    {
        florist.MovePosition(florist.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
