using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountdownTimerScript : MonoBehaviour{
    [SerializeField] public Text timeLeft;
    private int timeAmount = 10;
    private static int dayCount = 1;
    Global g = new Global();
    private Queue orders = Global.orders;
    private int money = 0;

    void Start()
    {
        StartCoroutine("timeDown");
    }

    // Update is called once per frame
    void Update(){
        timeLeft.text = "Time Left: " + timeAmount.ToString();

        if (timeAmount <= 0 && dayCount <= 2){
            completeOrders();
            SceneManager.LoadScene("Store" + dayCount);
        }
        else if (timeAmount <= 0 && dayCount >= 3){
            completeOrders();
            SceneManager.LoadScene("CareerStats");
        }
    }

    public IEnumerator timeDown()
    {
        yield return new WaitForSeconds(1.0f);
        timeAmount--;
        if (timeAmount != 0)
            StartCoroutine("timeDown");
    }

    public static void addDay()
    {
        dayCount++;
    }

    public static void setDay1()
    {
        dayCount = 1;
    }

    private void completeOrders(){
        while (orders.Count > 0){
            int currOrder = (int) orders.Dequeue();
            if (Global.plantsReady >= currOrder){
                money += (50 * currOrder);
                CareerStats.moneyEarnedStat(50 * currOrder);
                Debug.Log(50 * currOrder);
                Global.plantsReady -= currOrder;
            }
            else{
                money -= 20;
                CareerStats.moneyOrderUnfulfilled();
            }
        }
        Global.money += money;
        Global.plantsReady = 0;
        Global.orders.Clear();
    }

}
