using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FrameUIAudioData : MonoBehaviour
{
    [SerializeField] TMP_Text titleText;
    [SerializeField] GameObject[] difficultyStars;
    [SerializeField] GameObject lockImage;
    public AudioDataSelector audioDataSelector;
    //public BalanceManager balanceManager;
    public PurchasePopupManager purchasePopupManager;
    public int id;
    public bool purchased = false;
    public void ConfigureUIObject(string text)
    {
        titleText.text = text;
    }

    public void ButtonHandler()
    {
        SetSelectedTrack();
    }

    public void SetSelectedTrack()
    {
        if (purchased)
        {

            audioDataSelector.selectedAudioData = id;
            Debug.Log("Purchased: " + purchased);
        }
        else
        {
            purchasePopupManager.ActivateUnlockPopup(id);
        }
    }

    public void EnableDifficultyStars(int number)
    {
        if (number <= 5)
        {
            for (int i = 0; i < number; i++)
            {
                difficultyStars[i].SetActive(true);
            }
        }
    }

    /*public void UnlockTrack()
    {
        if (balanceManager.TryUnlockingTrack(id))
        {
            DisableLockImage();
        }
        else
        {
            // Rewarded ad pop up
        }
        
    }*/

    public void DisableLockImage()
    {
        lockImage.SetActive(false);
        purchased = true;
    }
}
