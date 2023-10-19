using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using TMPro;

public class EventSubcriber : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowAdv();

    [SerializeField] public AudioVisualizerManager visualizerManager;
    [SerializeField] GameObject nail;
    [SerializeField] GameObject movingBeam;
    [SerializeField] GameObject levelCompletedPopUp;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] PauseMenu pauseMenu;

    //TEST
    int nailCounter = 0;
    float timeCounter;
    public float trackLength;
    private bool gameEnd = false;
    [SerializeField] public List<float> beats;
    /*private void OnEnable()
    {
        visualizerManager.OnPeakReachedAction += Handler;
    }

    private void OnDisable()
    {
        visualizerManager.OnPeakReachedAction -= Handler;
    }

    private void Handler()
    {
        var newNail = Instantiate(nail, new Vector2(-9.19f, -2.2f), Quaternion.identity);
        newNail.transform.parent = movingBeam.transform;
    }*/

    private void Update()
    {
        timeCounter += Time.deltaTime;
        SpawnNailsFromList(timeCounter); // Spawning from list

        if (timeCounter >= trackLength && !gameEnd)
        {
            Progress.Instance.completedLevels++;
            if (Progress.Instance.completedLevels >= 2)
            {
                ShowAdv();
                Progress.Instance.incompletedLevels = 0;
                Progress.Instance.completedLevels = 0;
            }
            gameEnd = true;
            // Game end logic here, play add and enable pop up afterwards
            Debug.Log("Game End");
            levelCompletedPopUp.SetActive(true);

            if (scoreManager.GetScore() > Progress.Instance.playerInfo.record)
            {
                Progress.Instance.playerInfo.record = scoreManager.GetScore();
                Progress.Instance.Save();

                scoreText.text = "����� ������: " + scoreManager.GetScore() + "! �������: 50!";
            }
            else
            {
                scoreText.text = "������: " + Progress.Instance.playerInfo.record + ", ��� ���������: " + scoreManager.GetScore() + "! �������: 50!";
            }
        }
    }

    public void ShowRewardedAd(int val)
    {
        BalanceManager.Instance.AddCoinsExternMethod(val);
        pauseMenu.BackToMainMenu();
    }

    private void SpawnNailsFromList(float timeCounter)
    {
        if  (beats.Count > nailCounter && (timeCounter >= beats[nailCounter]))
        {
            nailCounter++;
            var newNail = Instantiate(nail, new Vector2(-9.19f, -2.2f), Quaternion.identity);
            newNail.transform.parent = movingBeam.transform;
        }
    }
}