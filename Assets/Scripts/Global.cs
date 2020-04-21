using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This class is used to store variables that will carry from scene to scene and from class to class
 */
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
    public static int plantsNeeded = 0;
    private Button _button;
    private Button _button1;
    private Button _button2;


    public Global(){}

    void Start(){
        _button2 = sink.GetComponent<Button>();
        _button1 = can.GetComponent<Button>();
        _button = shoes.GetComponent<Button>();
    }

    void Update()
    {
        moneyLeft.text = "Current Wallet: $" + money.ToString();
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
