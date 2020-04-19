using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OwnedItems : MonoBehaviour
{
    public static bool ownShoes;
    public static bool ownFertilizer;
    public static bool ownSink;
    public static int amountFertilizer;
    public static int currentShoes = 0;
    public static int currentSink = 0;
    public static int shoesMax = 1;
    public static int sinkMax = 1;

    public static void doesOwnShoes()
    {
        ownShoes = true;
        currentShoes++;
    }

    public static void doesOwnFertilizer()
    {
        ownFertilizer = true;
    }

    public static void doesOwnSink()
    {
        ownSink = true;
        currentSink++;
    }

    public static void addFertilizer()
    {
        amountFertilizer++;
    }

    public static bool ifOwnShoes()
    {
        if (currentShoes >= 1)
            return true;
        else
            return false;
    }

    public static bool ifOwnSink()
    {
        if (currentSink >= 1)
            return true;
        else 
            return false;
    }

    public static void resetOwnedItems()
    {
        currentShoes = 0;
        amountFertilizer = 0;
        currentSink = 0;
    }

}
