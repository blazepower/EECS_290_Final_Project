using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBenefits : MonoBehaviour
{
    public GameObject sink;
    public GameObject can;

    public static SpriteRenderer sinkSprite;
    public static SpriteRenderer canSprite;

    public Sprite normalSink;
    public Sprite upgradedSink;
    public Sprite normalCan;
    public Sprite upgradedCan;

    // Start is called before the first frame update
    void Start()
    {
        sinkSprite = sink.GetComponent<SpriteRenderer>();
        canSprite = can.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Shoes
        if (OwnedItems.ifOwnShoes() == true)
        {
            WASDMove.shoesMovespeed();
        }
        else
        {
            WASDMove.normalMovespeed();
        }

        //Can
        if (OwnedItems.ifOwnCan() == true)
        {
            canSprite.sprite = upgradedCan;
            CanStatus.setUpgradedCan();
        }
        else
        {
            canSprite.sprite = normalCan;
            CanStatus.setNormalCan();
        }

        //Sink
        if (OwnedItems.ifOwnSink() == true)
        {
            sinkSprite.sprite = upgradedSink;
            CanStatus.setUpgradedFill();
        }
        else
        {
            sinkSprite.sprite = normalSink;
            CanStatus.setNormalFill();
        }
    }
}
