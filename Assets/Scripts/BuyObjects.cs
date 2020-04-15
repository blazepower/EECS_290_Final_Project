using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyObjects : MonoBehaviour{
    public Color highlightColorIfNotBuyable = Color.gray;
    public Color highlightColorIfBuyable = Color.magenta;
    private static bool _bought;
    public int _price;
    Global _global = new Global();
    private int money = Global.money;
    

    public void OnMouseEnter(){
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (!_bought){
            sprite.color = highlightColorIfBuyable;
        }

        if (_bought){
            sprite.color = highlightColorIfNotBuyable;
        }
    }

    public void OnMouseUp(){
        if (_price <= money){
            _bought = true;
            Global.money -= _price;
        }
    }
}