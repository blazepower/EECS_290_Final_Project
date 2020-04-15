using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountdownTimerScript : MonoBehaviour{
    [SerializeField] private Text timeLeft;
    private int timeAmount = 75;

    void Start()
    {
        StartCoroutine("timeDown");
    }

    // Update is called once per frame
    void Update(){

        //timeAmount -= Time.deltaTime;
        timeLeft.text = "Time Left: " + timeAmount.ToString();

        if (timeAmount < 0){
            SceneManager.LoadScene("Store");
        }
    }

    public IEnumerator timeDown()
    {
        yield return new WaitForSeconds(1.0f);
        timeAmount--;
        if (timeAmount != 0)
            StartCoroutine("timeDown");
    }

}
