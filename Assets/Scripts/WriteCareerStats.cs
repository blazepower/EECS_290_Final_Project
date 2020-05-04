using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WriteCareerStats : MonoBehaviour
{
    [SerializeField] public Text stats;
    public static int plantsBloomed;
    public static int plantsDead;
    public static int moneyEarned;
    public static int moneyLost;
    public static int moneySpent;
    public static int initialWallet;
    public static int totalIncome;
    public static int endingWallet;

    void Start()
    {
        plantsBloomed = CareerStats.getPlantsBloomed();
        plantsDead = CareerStats.getPlantsDead();
        moneyEarned = CareerStats.getMoneyEarned();
        moneyLost = CareerStats.getMoneyLost();
        moneySpent = CareerStats.getMoneySpent();
        initialWallet = Global.getInitialMoney();
        totalIncome = moneyEarned - moneyLost - moneySpent;
        endingWallet = Global.getMoney();

        stats.text = "Total Plants Bloomed: " + plantsBloomed.ToString() + "\n" +
                     "Total Plants Dead: "    + plantsDead.ToString()    + "\n" +
                     "Total Money Earned: $"  + moneyEarned.ToString()   + "\n" +
                     "Total Money Lost: $"    + moneyLost.ToString()     + "\n" +
                     "Total Money Spent: $"   + moneySpent.ToString()    + "\n" +
                     "Initial Wallet: $"      + initialWallet.ToString() + "\n" +
                     "Total Income: $"        + totalIncome.ToString()   + "\n" +
                     "Ending Wallet: $"       + endingWallet.ToString();
    }

}
