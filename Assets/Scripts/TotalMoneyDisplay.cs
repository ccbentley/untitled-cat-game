using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TotalMoneyDisplay : MonoBehaviour
{
    public UnityEvent goalReached;
    public TMP_Text totalMoneyText;
    public float totalMoneyToBreak = 1000;

    private void Update()
    {
        totalMoneyText.text = "TOTAL AMOUNT DESTROYED: $" + Variables.totalMoney.ToString() + " / $" + totalMoneyToBreak;
        if(Variables.totalMoney >= totalMoneyToBreak)
        {
            goalReached.Invoke();
        }
    }

    private void Start()
    {
        Variables.totalMoney = 0;
    }
}
