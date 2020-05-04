using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBenefits : MonoBehaviour
{
    public GameObject sink;
    //public GameObject can;

    public SpriteRenderer sinkSprite;
    public SpriteRenderer canSprite;

    public Sprite normalSink;
    public Sprite upgradedSink;
    public Sprite normalCan;
    public Sprite upgradedCan;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = sink.GetComponent<Animator>();
        if (OwnedItems.ifOwnSink() == true)
            animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("UpgradedSink");
        else
            animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Sink");
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
