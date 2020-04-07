using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour{
    public Vector3 mousePos;

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        transform.position = Vector3.MoveTowards(transform.position, mousePos, Time.deltaTime * 5);
    }
}
