using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanStatus : MonoBehaviour
{
    public static int capacity = 50;
    public static int staticAmount;
    public int amount;
    public static float fillSpeed;

    public SpriteRenderer spriteRenderer;
    public AudioSource cantWater;

    // Start is called before the first frame update
    void Start()
    {
        staticAmount = 25;
    }

    static int gate = 0;
    static int soundPrevent = 0;
    // Update is called once per frame
    void Update()
    {
        amount = staticAmount;

        if (adding == true && gate == 0 && SinkInteractable.isInteractable() == true)
        {
            StartCoroutine("filling");
            gate++;
        }
        if (soundPrevent == 0 && amount == 0)
        {
            cantWater.Play();
            soundPrevent++;
        }
    }

    public static void Subtract()
    {
        staticAmount--;
    }

    private static bool adding = false;

    public static void Add()
    {
        adding = true;
    }

    public static void StopAdd()
    {
        adding = false;
        gate = 0;
    }

    public IEnumerator filling()
    {
        while (staticAmount < capacity && adding == true && SinkInteractable.isInteractable() == true)
        {
            yield return new WaitForSeconds(fillSpeed);
            staticAmount++;
            soundPrevent = 0;
        }
    }

    public static bool isEmpty()
    {
        if (staticAmount == 0)
        {
            return true;
        } 
        else
        {
            return false;
        }
    }

    public static int getAmount()
    {
        return staticAmount;
    }

    public static void setNormalFill()
    {
        fillSpeed = 0.1f;
    }

    public static void setUpgradedFill()
    {
        fillSpeed = 0.05f;
    }
}

