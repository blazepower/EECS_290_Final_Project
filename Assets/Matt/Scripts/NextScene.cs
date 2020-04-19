using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour
{
    public void StartGame()
    {
        Application.LoadLevel("StartGame");
    }

    public void KeybindsScene()
    {
        Application.LoadLevel("KeybindsScene");
    }

    public void Day1()
    {
        CountdownTimerScript.setDay1();
        Application.LoadLevel("Day1");
    }

    public void Day2()
    {
        CountdownTimerScript.addDay();
        Application.LoadLevel("Day2");
    }

    public void Day3()
    {
        CountdownTimerScript.addDay();
        Application.LoadLevel("Day3");
    }

    public void EndGame()
    {
        Application.LoadLevel("EndGame");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
