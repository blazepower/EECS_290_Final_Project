using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorePrices : MonoBehaviour
{
    public static int shoesPrice = 300;
    public static int canPrice = 400;
    public static int sinkPrice = 200;

    public static int getShoesPrice()
    {
        return shoesPrice;
    }

    public static int getCanPrice()
    {
        return canPrice;
    }

    public static int getSinkPrice()
    {
        return sinkPrice;
    }


}
