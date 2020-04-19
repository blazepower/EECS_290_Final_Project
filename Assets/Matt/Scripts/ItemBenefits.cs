using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBenefits : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (OwnedItems.ifOwnShoes() == true)
            WASDMove.shoesMovespeed();
        else
            WASDMove.normalMovespeed();
    }
}
