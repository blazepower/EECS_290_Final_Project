using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetVars : MonoBehaviour
{
    void Start()
    {
        OwnedItems.resetOwnedItems();
        Global.resetMoney();
    }
}
