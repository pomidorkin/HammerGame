using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManuMediator : MonoBehaviour
{
    public void StartGame()
    {
        AudioDataSelector.Instance.StartGame();
    }
}
