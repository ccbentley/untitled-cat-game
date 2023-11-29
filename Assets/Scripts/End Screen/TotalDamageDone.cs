using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalDamageDone : MonoBehaviour
{
    public TMP_Text totalMoneyText;
    int totalMoney;

    public string beforeText;
    public string afterText;

    private void Start()
    {
        totalMoney = Variables.totalMoney;
        totalMoneyText.text = beforeText + totalMoney.ToString() + afterText;
    }
}
