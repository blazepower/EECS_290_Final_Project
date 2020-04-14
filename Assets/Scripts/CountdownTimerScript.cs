using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountdownTimerScript : MonoBehaviour{
    private float timeLeft = 300.0f;

    // Update is called once per frame
    void Update(){
        timeLeft -= Time.deltaTime;

        if (timeLeft < 0){
            SceneManager.LoadScene("Store");
        }
    }
    
}
