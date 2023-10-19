using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuUi;
    [SerializeField] AudioManager audioManager;

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuUi.SetActive(true);
        audioManager.PauseAudio();
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuUi.SetActive(false);
        audioManager.ResumeAudio();
    }

    public void BackToMainMenu()
    {
       SceneManager.LoadScene(0);
    }

    public void AddBalanceGoToMenu()
    {
        Progress.Instance.incompletedLevels++;
        Progress.Instance.playerInfo.coins += 50;
        Progress.Instance.Save();
        SceneManager.LoadScene(0);
    }

}
