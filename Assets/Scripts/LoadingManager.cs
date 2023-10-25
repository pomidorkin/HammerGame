using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plugins.Audio.Core;
using System;

public class LoadingManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    private void OnEnable()
    {
        if (AudioManagement.Instance.loadingCompleted)
        {
            OnTracksLoadedHandler();
        }
        AudioManagement.Instance.OnAllTrackLoaded += OnTracksLoadedHandler;
    }

    private void OnDisable()
    {
        AudioManagement.Instance.OnAllTrackLoaded -= OnTracksLoadedHandler;
    }

    private void OnTracksLoadedHandler()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
