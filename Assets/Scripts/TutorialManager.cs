using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject tutorialPopup;
    [SerializeField] PopulateScrollPanel populateScrollPanelScript;

    private void Start()
    {
        if (!Progress.Instance.playerInfo.firstStart)
        {
            if (!Progress.Instance.playerInfo.purchasedTracksId.Contains(0))
            {
                Progress.Instance.playerInfo.purchasedTracksId.Add(0);
                populateScrollPanelScript.frameUIAudioDatas[0].DisableLockImage();
            }
            Progress.Instance.playerInfo.firstStart = true;
            Progress.Instance.Save();
            tutorialPopup.SetActive(true);
        }
    }

    public void CloseTutorial()
    {
        tutorialPopup.SetActive(false);
    }
}
