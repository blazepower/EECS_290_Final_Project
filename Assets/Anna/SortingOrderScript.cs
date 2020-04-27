using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingOrderScript : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Rigidbody2D florist;
    public Rigidbody2D can;

    public Vector2 movement;
    private float yMove;

    void Update()
    {
        yMove = Input.GetAxisRaw("Vertical");

        if (florist.transform.position.y <= .7 && florist.transform.position.y >= .5 && yMove == -1)
        {
            Debug.Log("Body covers counter");
        }

        //if (body.position.y == counter.position.y) //&& Mathf.Sign(body.movement.y) == 1)
        //{
            //Debug.Log("Counter covers body");
        //}

    }

    //private IEnumerator bodyOnTop()
    //{
    //    Debug.Log("Body covers counter");
    //}

    //private IEnumerator counterOnTop()
    //{
    //    Debug.Log("Counter covers body");
    //}
}
