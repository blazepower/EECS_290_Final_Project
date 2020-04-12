using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkFill : MonoBehaviour{
    public Color highlightColor = Color.cyan;
    private Color standard = new Color(255f, 255f ,255f, 255f);
    private bool hover = false;

    void Update()
    {
        if (hover == true && SinkInteractable.isInteractable() == true)
        {
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            if (sprite != null)
            {
                sprite.color = highlightColor;
            }
        }
        else
        {
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            if (sprite != null)
            {
                sprite.color = standard;
            }
        }
    }

    public void OnMouseEnter()
    {
        hover = true;
    }

    public void OnMouseExit()
    {
        hover = false;
    }

    public void OnMouseDown()
    {
        if (SinkInteractable.isInteractable() == true)
            CanStatus.Add();
    }

    public void OnMouseUp()
    {
        if (SinkInteractable.isInteractable() == true)
            CanStatus.StopAdd();
    }

    
}
