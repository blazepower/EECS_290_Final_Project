using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This class is used to store variables that will carry from scene to scene and from class to class
 */
public class Global : MonoBehaviour{
    public static int money = 240;
    public static int shoesPrice = StorePrices.getShoesPrice();
    public static int canPrice = StorePrices.getCanPrice();
    public static int sinkPrice = StorePrices.getSinkPrice();
    public GameObject shoes;
    public GameObject can;
    public GameObject sink;
    public GameObject shoesPurchaseConfirmation;
    public GameObject canPurchaseConfirmation;
    public GameObject sinkPurchaseConfirmation;
    public static int plantsReady = 0;
    public static int plantsNeeded = 0;
    private Button _button;
    private Button _button1;
    private Button _button2;
    public static Queue orders = new Queue();


    public Global(){}

    void Start(){
        plantsNeeded = 0;
        plantsReady = 0;
        _button2 = sink.GetComponent<Button>();
        _button1 = can.GetComponent<Button>();
        _button = shoes.GetComponent<Button>();
    }

    void Update()
    {
        if (money < shoesPrice || OwnedItems.ifOwnShoes() == true)
        {
            _button.interactable = false;
        }
        if (money < canPrice || OwnedItems.ifOwnCan() == true)
        {
            _button1.interactable = false;
        }
        if (money < sinkPrice || OwnedItems.ifOwnSink() == true)
        {
            _button2.interactable = false;
        }
    }


    public void buyShoes()
    {
        if (money >= shoesPrice)
        {
            OwnedItems.doesOwnShoes();
            money = money - shoesPrice;
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
            OwnedItems.doesOwnCan();
            money = money - canPrice;
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
            OwnedItems.doesOwnSink();
            money = money - sinkPrice;
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
        money = 240;
    }

    public static void plantDeadDeduction()
    {
        money = money - 50;
    }

    public static void plantBloomed(){
        plantsReady++;
    }

    public static int getMoney()
    {
        return money;
    }

    public static int getPlantsNeeded()
    {
        return plantsNeeded;
    }
}
