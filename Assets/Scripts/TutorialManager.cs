using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject tutorialPopup;

    private void Start()
    {
        if (!Progress.Instance.playerInfo.firstStart)
        {
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
