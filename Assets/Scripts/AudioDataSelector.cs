using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioDataSelector : MonoBehaviour
{

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

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
