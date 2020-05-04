using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanStatus : MonoBehaviour
{
    public static int capacity;
    public static int staticAmount;
    public int amount;
    public static float fillSpeed;
    public Animator animator;

    public AudioSource cantWater;

    // Start is called before the first frame update
    void Start()
    {
        if (OwnedItems.ownCan){
            staticAmount = 100;
        }
        else{
            staticAmount = 50;
        }
        
    }

    static int gate = 0;
    static int soundPrevent = 0;
    // Update is called once per frame
    void Update()
    {
        amount = staticAmount;
        //Turn sink water on and off
        animator.SetBool("sinkOn", adding);

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
            return true;
        else
            return false;
    }
    
    public static bool isFull()
    {
        if (staticAmount == capacity)
            return true;
        else
            return false;
    }

    public static int getAmount()
    {
        return staticAmount;
    }

    public static void setNormalCan()
    {
        capacity = 50;
    }

    public static void setUpgradedCan()
    {
        capacity = 100;
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

