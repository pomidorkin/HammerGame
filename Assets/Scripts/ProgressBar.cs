using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] Slider progressBar;
    [SerializeField] EventSubcriber eventSubcriber;
    private float timeCounter = 0;
    private float timer = 0;
    private float trackLength;
    private bool started = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayedStart());
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            float deltaTime = Time.deltaTime;
            timer += deltaTime;
            timeCounter += deltaTime;
            if (timer >= 0.5f && timeCounter != 0)
            {
                float progress = 1 / (trackLength / timeCounter);
                if (progress < 1)
                {
                    progressBar.value = progress;
                }
                timer = 0;
            }
        }
    }

    private IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(3);
        trackLength = eventSubcriber.trackLength;
        started = true;
    }
}
