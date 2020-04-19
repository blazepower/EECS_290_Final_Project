using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyObjects : MonoBehaviour{
    public int _price;
    Global _global = new Global();
    private int money = Global.money;

    void Start()
    {
        if (money < _price)
        {
            GetComponent<Button>().interactable = false;
        }
    }
    
}