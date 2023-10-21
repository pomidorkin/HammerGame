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
        Progress.Instance.incompletedLevels++;
        SceneManager.LoadScene(0);
    }

    public void AddBalanceGoToMenu()
    {
        BalanceManager.Instance.AddCoins(50);
        SceneManager.LoadScene(0);
    }

}
