using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BalanceTextUpdater : MonoBehaviour
{
    [SerializeField] TMP_Text balanceText;

    private void Start()
    {
        UpdateBalanceText();
    }

    public void UpdateBalanceText()
    {
        balanceText.text = "Баланс: " + BalanceManager.Instance.GetBalance();
    }
}
