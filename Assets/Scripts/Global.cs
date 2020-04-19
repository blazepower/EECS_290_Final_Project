using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Global : MonoBehaviour{
    [SerializeField] public Text moneyLeft;
    public static int money = 300;
    public static int shoesPrice = StorePrices.getShoesPrice();
    public static int fertilizerPrice = StorePrices.getFertilizerPrice();
    public static int sinkPrice = StorePrices.getSinkPrice();
    public GameObject shoes;
    public GameObject fertilizer;
    public GameObject sink;
    public GameObject shoesPurchaseConfirmation;
    public GameObject fertilizerPurchaseConfirmation;
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
        if (money < fertilizerPrice)
        {
            fertilizer.GetComponent<Button>().interactable = false;
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

    public void buyFertilizer()
    {
        if (money >= fertilizerPrice)
        {
            money = money - fertilizerPrice;
            OwnedItems.doesOwnFertilizer();
            OwnedItems.addFertilizer();
        }
        else
        {
            Debug.Log("Not enough money");
        }
        Debug.Log(money);
        fertilizerPurchaseConfirmation.SetActive(false);
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

    public void enableFertilizerPurchaseConfirmation()
    {
        fertilizerPurchaseConfirmation.SetActive(true);
    }

    public void disableFertilizerPurchaseConfirmation()
    {
        fertilizerPurchaseConfirmation.SetActive(false);
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
        money = 300;
    }
}
