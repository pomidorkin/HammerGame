using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioDataSelector : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowAdv();

    public static AudioDataSelector Instance;
    [SerializeField] public AudioDataScriptableObject[] audioDataObjects;
    public int selectedAudioData = 0;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        BalanceManager.Instance.UpdateBalance();
        if (Progress.Instance.incompletedLevels >= 3)
        {
            ShowAdv();
            Progress.Instance.incompletedLevels = 0;
            Progress.Instance.completedLevels = 0;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
