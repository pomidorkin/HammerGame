using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualizerManager : MonoBehaviour
{
    [SerializeField] [Range(0, 7)] public int band = 0;
    [SerializeField] [Range(0f, 10f)] public float animTriggerValue = 1.6f;
    float elapsedTime;
    [SerializeField] public float timeLimit = 0.1f;

    public delegate void PeakReachedAction();
    public event PeakReachedAction OnPeakReachedAction;

    // Test
    [SerializeField] List<float> beats;
    float beatCounter;

    /*void Update()
    {
        beatCounter += Time.deltaTime;
        elapsedTime += Time.deltaTime;

        //Logic for setting up
        if (elapsedTime >= timeLimit && AudioPeer.bandBuffer[band] > animTriggerValue)
        {
            elapsedTime = 0;
            OnPeakReachedAction();
            beats.Add(beatCounter);
        }
    }*/
}