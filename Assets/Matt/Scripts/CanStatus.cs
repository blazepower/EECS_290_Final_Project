using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanStatus : MonoBehaviour
{
    public static int capacity = 50;
    public static int staticAmount;
    public int amount;

    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        staticAmount = 5;
    }

    static int gate = 0;
    // Update is called once per frame
    void Update()
    {
        amount = staticAmount;

        if (adding == true && gate == 0)
        {
            StartCoroutine("filling");
            gate++;
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
        while (staticAmount < capacity && adding == true)
        {
            yield return new WaitForSeconds(0.1f);
            staticAmount++;
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
}

