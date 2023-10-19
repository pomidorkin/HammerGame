using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateScrollPanel : MonoBehaviour
{
    [SerializeField] List<AudioDataScriptableObject> audioDataObjects;
    public List<FrameUIAudioData> frameUIAudioDatas;
    [SerializeField] GameObject panel;
    [SerializeField] FrameUIAudioData audioDataUIObject;
    //[SerializeField] AudioDataSelector audioDataSelector;
    //[SerializeField] BalanceManager balanceManager;
    [SerializeField] PurchasePopupManager purchasePopupManager;
    private int UIElementCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach (AudioDataScriptableObject item in audioDataObjects)
        {
            FrameUIAudioData newUIObject = Instantiate(audioDataUIObject, new Vector2(0, 0), Quaternion.identity);
            newUIObject.transform.SetParent(panel.transform);
            newUIObject.ConfigureUIObject(item.trackName);
            newUIObject.transform.localScale = new Vector3(1, 1, 1);
            newUIObject.id = UIElementCounter;
            newUIObject.audioDataSelector = AudioDataSelector.Instance;
            newUIObject.EnableDifficultyStars(item.difficulty);
            //newUIObject.balanceManager = balanceManager;
            newUIObject.purchasePopupManager = purchasePopupManager;
            if (Progress.Instance.playerInfo.purchasedTracksId.Contains(newUIObject.id) || item.defaultTrack)
            {
                newUIObject.DisableLockImage();
            }
            frameUIAudioDatas.Add(newUIObject);
            UIElementCounter++;
        }
    }
}
