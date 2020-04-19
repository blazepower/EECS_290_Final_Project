using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDMove : MonoBehaviour
{
    public static int moveSpeed = 9;
    public int moveSpeedDisplay = moveSpeed;
    public Rigidbody2D florist;
    Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        florist.MovePosition(florist.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public static void shoesMovespeed()
    {
        moveSpeed = 12;
    }

    public static void normalMovespeed()
    {
        moveSpeed = 8;
    }
}
