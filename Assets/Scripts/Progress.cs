using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    public int coins = 0;
    public List<int> purchasedTracksId;
    public int record;
    public bool firstStart = false;
}

public class Progress : MonoBehaviour
{
    public PlayerInfo playerInfo;

    [DllImport("__Internal")]
    private static extern void SaveExtern(string data);

    [DllImport("__Internal")]
    private static extern void LoadExtern();

    [DllImport("__Internal")]
    private static extern void ShowAdv();

    public static Progress Instance;
    public int completedLevels = 0;
    public int incompletedLevels = 0;

    // Было Awake стало OnEnable
    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            //LoadExtern();
            SetPlayerInfoLocal();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ShowAdv();
    }

    public void Save()
    {
        string jsonString = JsonUtility.ToJson(playerInfo);
        //SaveExtern(jsonString);
        PlayerPrefs.SetString("data", jsonString);
        PlayerPrefs.Save();
    }

    public void SetPlayerInfo(string value)
    {
        if (value != null)
        {
            playerInfo = JsonUtility.FromJson<PlayerInfo>(value);
        }
        else
        {
            playerInfo = new PlayerInfo();
            Save();
        }
    }

    public void SetPlayerInfoLocal()
    {
        playerInfo = JsonUtility.FromJson<PlayerInfo>(PlayerPrefs.GetString("data"));
        Debug.Log(PlayerPrefs.GetString("data"));
        if (playerInfo == null)
        {
            playerInfo = new PlayerInfo();
            Save();
        }
        
        
    }
}
