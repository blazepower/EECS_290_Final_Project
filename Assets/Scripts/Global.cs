using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Global : MonoBehaviour{
    [SerializeField] public Text moneyLeft;
    public static int money = 900;
    public static int shoesPrice = StorePrices.getShoesPrice();
    public static int canPrice = StorePrices.getCanPrice();
    public static int sinkPrice = StorePrices.getSinkPrice();
    public GameObject shoes;
    public GameObject can;
    public GameObject sink;
    public GameObject shoesPurchaseConfirmation;
    public GameObject canPurchaseConfirmation;
    public GameObject sinkPurchaseConfirmation;

    public Global(){}

    void Start()
    {

    }

    void Update()
    {
        moneyLeft.text = "Current Wallet: $" + money.ToString();
        if (money < shoesPrice || OwnedItems.ifOwnShoes() == true)
        {
            shoes.GetComponent<Button>().interactable = false;
        }
        if (money < canPrice || OwnedItems.ifOwnCan() == true)
        {
            can.GetComponent<Button>().interactable = false;
        }
        if (money < sinkPrice || OwnedItems.ifOwnSink() == true)
        {
            sink.GetComponent<Button>().interactable = false;
        }
    }


    public void buyShoes()
    {
        if (money >= shoesPrice)
        {
            money = money - shoesPrice;
            OwnedItems.doesOwnShoes();
        }
        else
        {
            Debug.Log("Not enough money");
        }
        Debug.Log(money);
        shoesPurchaseConfirmation.SetActive(false);
    }

    public void buyCan()
    {
        if (money >= canPrice)
        {
            money = money - canPrice;
            OwnedItems.doesOwnCan();
        }
        else
        {
            Debug.Log("Not enough money");
        }
        Debug.Log(money);
        canPurchaseConfirmation.SetActive(false);
    }

    public void buySink()
    {
        if (money >= sinkPrice)
        {
            money = money - sinkPrice;
            OwnedItems.doesOwnSink();
        }
        else
        {
            Debug.Log("Not enough money");
        }
        Debug.Log(money);
        sinkPurchaseConfirmation.SetActive(false);
    }

    public void enableShoesPurchaseConfirmation()
    {
        shoesPurchaseConfirmation.SetActive(true);
    }

    public void disableShoesPurchaseConfirmation()
    {
        shoesPurchaseConfirmation.SetActive(false);
    }

    public void enableCanPurchaseConfirmation()
    {
        canPurchaseConfirmation.SetActive(true);
    }

    public void disableCanPurchaseConfirmation()
    {
        canPurchaseConfirmation.SetActive(false);
    }

    public void enableSinkPurchaseConfirmation()
    {
        sinkPurchaseConfirmation.SetActive(true);
    }

    public void disableSinkPurchaseConfirmation()
    {
        sinkPurchaseConfirmation.SetActive(false);
    }

    public static void resetMoney()
    {
        money = 900;
    }
}
