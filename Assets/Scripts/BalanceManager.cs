using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine.SceneManagement;

public class BalanceManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void AddCoinsExtern(int value);

    public static BalanceManager Instance;

    private int balance = 0;
    public int unlockPrice = 250;
    //[SerializeField] TMP_Text balanceText;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
/*
    private void OnEnable()
    {
        balance = Progress.Instance.playerInfo.coins;
        balanceText.text = balance.ToString();
    }*/

    public bool TryUnlockingTrack(int id)
    {
        if ((balance - unlockPrice) >= 0)
        {
            Progress.Instance.playerInfo.coins -= unlockPrice;
            Progress.Instance.playerInfo.purchasedTracksId.Add(id);
            UpdateBalance();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void UpdateBalance()
    {
        balance = Progress.Instance.playerInfo.coins;
        Progress.Instance.Save();
    }

    public void AddCoinsExternMethod(int val)
    {
        AddCoinsExtern(val);
    }

    public void AddCoins(int val)
    {
        Progress.Instance.playerInfo.coins += val;
        UpdateBalance();
    }

    public void AddCoinsAndGoBack(int val)
    {
        Progress.Instance.playerInfo.coins += val;
        UpdateBalance();
        SceneManager.LoadScene(0);
    }

    public int GetBalance()
    {
        return balance;
    }
}
