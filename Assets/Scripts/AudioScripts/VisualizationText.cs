using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VisualizationText : MonoBehaviour
{
    [SerializeField] TMP_Text firstTest, secondText, thirdText;
    float maxOne, maxTwo, maxThree = 0f;

    void Update()
    {
        if (AudioPeer.bandBuffer[0] > maxOne)
        {
            maxOne = AudioPeer.bandBuffer[0];
        }
        if (AudioPeer.bandBuffer[1] > maxTwo)
        {
            maxTwo = AudioPeer.bandBuffer[1];
        }
        if (AudioPeer.bandBuffer[2] > maxThree)
        {
            maxThree = AudioPeer.bandBuffer[2];
        }
        // My code for visualization
        firstTest.text = "0 to 60 hertz: " + AudioPeer.bandBuffer[0]+ " Max recorded value: " + maxOne;
            secondText.text = "60 to 250 hertz: " + AudioPeer.bandBuffer[1] + " Max recorded value: " + maxTwo;
            thirdText.text = "250 to 500 hertz: " + AudioPeer.bandBuffer[2] + " Max recorded value: " + maxThree;

    }
}
