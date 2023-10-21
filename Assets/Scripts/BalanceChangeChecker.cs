using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class BalanceChangeChecker : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowAdv();
    private void Start()
    {
        BalanceManager.Instance.UpdateBalance();
        if (Progress.Instance.incompletedLevels >= 3)
        {
            ShowAdv();
            Progress.Instance.incompletedLevels = 0;
            Progress.Instance.completedLevels = 0;
        }
    }
}
