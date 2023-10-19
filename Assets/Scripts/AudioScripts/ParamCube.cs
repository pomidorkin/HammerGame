using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour
{
    public int band;
    public float startScale, scaleMultiplier;
    [SerializeField] bool useBuffer = true;
 
    void Update()
    {
        if (useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x,
            (AudioPeer.bandBuffer[band] * scaleMultiplier) + startScale,
            transform.localScale.z);

        }
        if (!useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x,
            (AudioPeer.frequencyBands[band] * scaleMultiplier) + startScale,
            transform.localScale.z);
        }

    }
}