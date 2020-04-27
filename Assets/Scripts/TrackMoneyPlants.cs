using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackMoneyPlants : MonoBehaviour
{
    [SerializeField] public Text moneyLeft;
    [SerializeField] public Text plantsNeed;
    public static int money;
    public static int plantsNeeded;


    void Update()
    {
        money = Global.getMoney();
        plantsNeeded = Global.getPlantsNeeded();
        moneyLeft.text = "Current Wallet: $" + money.ToString();
        plantsNeed.text = "Plants Needed: " + plantsNeeded.ToString();
    }
}
