using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantInteractable : MonoBehaviour
{
    public static bool interactable = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        interactable = true;
        Debug.Log("TRUE");
    }
    private void OnTriggerStay2d(Collider2D other)
    {
        interactable = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
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
