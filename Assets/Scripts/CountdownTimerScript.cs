using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountdownTimerScript : MonoBehaviour{
    [SerializeField] public Text timeLeft;
    private int timeAmount = 75;
    private static int dayCount = 1;

    void Start()
    {
        StartCoroutine("timeDown");
    }

    // Update is called once per frame
    void Update(){

        //timeAmount -= Time.deltaTime;
        timeLeft.text = "Time Left: " + timeAmount.ToString();

        if (timeAmount <= 0 && dayCount <= 2){
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

}
