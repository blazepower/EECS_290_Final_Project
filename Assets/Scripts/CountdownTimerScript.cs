using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountdownTimerScript : MonoBehaviour{
    [SerializeField] public Text timeLeft;
    private int timeAmount = 5;
    private static int dayCount = 1;
    Global g = new Global();
    private Queue orders = Global.orders;
    private int money = Global.money;
    private int plantsLeft = Global.plantsRemaining;

    void Start()
    {
        StartCoroutine("timeDown");
    }

    // Update is called once per frame
    void Update(){

        //timeAmount -= Time.deltaTime;
        timeLeft.text = "Time Left: " + timeAmount.ToString();

        if (timeAmount <= 0 && dayCount <= 2){
            completeOrders();
            Global.plantsRemaining = 0;
            Global.orders.Clear();
            SceneManager.LoadScene("Store" + dayCount);
        }
        else if (timeAmount <= 0 && dayCount >= 3){
            SceneManager.LoadScene("EndGame");
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
            if (plantsLeft >= currOrder){
                money += 50;
                plantsLeft -= currOrder;
            }
        }
        Global.money = money;
    }

}
