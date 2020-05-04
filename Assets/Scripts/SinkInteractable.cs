using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinkInteractable : MonoBehaviour
{
    public static bool interactable = false;

    void Start()
    {
        interactable = false;
    }

    void Update()
    {
        if (CanStatus.isFull() == true)
        {
            interactable = false;
            CanStatus.StopAdd();
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CanStatus.isFull() == true)
        {
            interactable = false;
            CanStatus.StopAdd();
        }
        else
        {
            interactable = true;
        }
        Debug.Log("TRUE");
    }
    private void OnTriggerStay2d(Collider2D other)
    {
        if (CanStatus.isFull() == true)
        {
            interactable = false;
            CanStatus.StopAdd();
        }
        else
        {
            interactable = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        CanStatus.StopAdd();
        interactable = false;
        Debug.Log("FALSE");
    }

    public static bool isInteractable()
    {
        if (interactable == true)
            return true;
        else
            return false;
    }

}
