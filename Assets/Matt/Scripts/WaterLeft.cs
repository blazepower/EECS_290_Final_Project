using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterLeft : MonoBehaviour
{
    [SerializeField] private Text waterLeft;
    private int waterAmount;


    void Update()
    {
        waterAmount = CanStatus.getAmount();

        waterLeft.text = waterAmount.ToString();
    }
}
