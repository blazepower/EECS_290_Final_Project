using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    public Vector3 targetPos;
    private float speed = 15;
    public bool isMoving = false;
    private bool didCollide = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SetTargetPosition();
        }

        if (isMoving == true)
        {
            Move();
        }
    }

    void SetTargetPosition()
    {
        targetPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        targetPos.z = 10;

        isMoving = true;
    }

    void Move()
    {
        //transform.rotation = Quaternion.LookRotation(Vector3.forward, targetPos);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (isMoving == false)
            return;

        if (transform.position == targetPos)
        {
            isMoving = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        isMoving = false;
    }

}