using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CareerStats : MonoBehaviour
{
    public static int plantsBloomed = 0;
    public static int plantsDead = 0;
    public static int totalMoneyEarned = 0;
    public static int totalMoneyLost = 0;
    public static int totalMoneySpent = 0;

    public static void addPlantsBloomed()
    {
        plantsBloomed++;
    }

    public static void addPlantsDead()
    {
        plantsDead++;
    }

    public static void moneyEarnedStat(int added)
    {
        totalMoneyEarned = totalMoneyEarned + added;
    }

    public static void moneyBoughtPlant()
    {
        totalMoneySpent = totalMoneySpent + 20;
    }

    public static void moneyPlantDied()
    {
        totalMoneyLost = totalMoneyLost + 50;
    }

    public static void moneyOrderUnfulfilled()
    {
        totalMoneyLost = totalMoneyLost + 20;
    }

    public static void spentMoney(int amount)
    {
        totalMoneySpent = totalMoneySpent + amount;
    }

    public static int getPlantsBloomed()
    {
        return plantsBloomed;
    }

    public static int getPlantsDead()
    {
        return plantsDead;
    }

    public static int getMoneyEarned()
    {
        return totalMoneyEarned;
    }

    public static int getMoneyLost()
    {
        return totalMoneyLost;
    }

    public static int getMoneySpent()
    {
        return totalMoneySpent;
    }

    public static void resetCareerStats()
    {
        plantsBloomed = 0;
        plantsDead = 0;
        totalMoneyEarned = 0;
        totalMoneyLost = 0;
        totalMoneySpent = 0;
    }
}
