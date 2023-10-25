using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PurchasePopupManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void UnblockTrackExtern();

    [SerializeField] GameObject unlockPopup;
    [SerializeField] GameObject adUnblockPopup;
    [SerializeField] PopulateScrollPanel populateScrollPanelScript;
    [SerializeField] BalanceTextUpdater balanceTextUpdater;
    
    private int id = 0;

    public void ActivateUnlockPopup(int id)
    {
        this.id = id;
        if (BalanceManager.Instance.GetBalance() >= BalanceManager.Instance.unlockPrice)
        {
            unlockPopup.SetActive(true);
        }
        else
        {
            adUnblockPopup.SetActive(true);
        }
    }

    public void UnlockTrack()
    {
        if (BalanceManager.Instance.TryUnlockingTrack(id))
        {
            //DisableLockImage();
            foreach (FrameUIAudioData item in populateScrollPanelScript.frameUIAudioDatas)
            {
                if (item.id == id)
                {
                    item.DisableLockImage();
                }
            }
            unlockPopup.SetActive(false);
            balanceTextUpdater.UpdateBalanceText();
        }
    }

    public void UnlockTrackViaAd()
    {
        UnblockTrackExtern();
    }

    public void UnlockTrackSuccess()
    {
        Progress.Instance.playerInfo.purchasedTracksId.Add(id);
        Progress.Instance.Save();
        Debug.Log("UnlockTrackSuccess, id: " + id + ", " + Progress.Instance.playerInfo.purchasedTracksId.ToString());
        populateScrollPanelScript.frameUIAudioDatas[id].DisableLockImage();
        adUnblockPopup.SetActive(false);
    }

    public void ClosePopups()
    {
        unlockPopup.SetActive(false);
        adUnblockPopup.SetActive(false);
    }
}
