using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class TotalMoneyDisplay : MonoBehaviour
{
    public TMP_Text totalMoneyText;
    int totalMoney;

    private void Update()
    {
        totalMoney = Variables.totalMoney;
        totalMoneyText.text = "TOTAL AMOUNT DESTROYED: $" + totalMoney.ToString();
    }

    private void Start()
    {
        Variables.totalMoney = 0;
    }
}
