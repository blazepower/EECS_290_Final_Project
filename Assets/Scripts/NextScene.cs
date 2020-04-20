using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("StartGame");
    }

    public void KeybindsScene()
    {
        SceneManager.LoadScene("KeybindsScene");
    }

    public void Day1()
    {
        CountdownTimerScript.setDay1();
        SceneManager.LoadScene("Day1");
    }

    public void Day2()
    {
        CountdownTimerScript.addDay();
        SceneManager.LoadScene("Day2");
    }

    public void Day3()
    {
        CountdownTimerScript.addDay();
        SceneManager.LoadScene("Day3");
    }

    public void EndGame()
    {
        SceneManager.LoadScene("EndGame");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
