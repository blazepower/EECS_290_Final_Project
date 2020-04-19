using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorePrices : MonoBehaviour
{
    public static int shoesPrice = 300;
    public static int fertilizerPrice = 50;
    public static int sinkPrice = 200;

    public static int getShoesPrice()
    {
        return shoesPrice;
    }

    public static int getFertilizerPrice()
    {
        return fertilizerPrice;
    }

    public static int getSinkPrice()
    {
        return sinkPrice;
    }


}
