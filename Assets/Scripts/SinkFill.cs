using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkFill : MonoBehaviour{
    private int maxCapacity = 50;
    [SerializeField] private GameObject waterCan;
    public Color highlightColor = Color.cyan;

    public void OnMouseEnter(){
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null){
            sprite.color = highlightColor;
        }
    }

    public void OnMouseDrag(){
        //while (waterCan.capacity <= maxCapacity){
            //waterCan.capacity += 10 * Time.deltaTime;
        //}
    }
    
}
