using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBenefits : MonoBehaviour
{
    public GameObject sink;
    public static SpriteRenderer sinkSprite;
    public Sprite normalSink;
    public Sprite upgradedSink;

    // Start is called before the first frame update
    void Start()
    {
        sinkSprite = sink.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OwnedItems.ifOwnShoes() == true)
        {
            WASDMove.shoesMovespeed();
        }
        else
        {
            WASDMove.normalMovespeed();
        }

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
