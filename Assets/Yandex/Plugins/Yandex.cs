using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Yandex : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void RateGame();

    [DllImport("__Internal")]
    private static extern void CheckCanReview();

    [SerializeField] GameObject rateGameButton;

    private void Start()
    {
        CheckCanReview();
    }

    public void RateGameBurtton()
    {
        RateGame();
    }

    public void EnableRateGameButton()
    {
        rateGameButton.SetActive(true);
    }
}
