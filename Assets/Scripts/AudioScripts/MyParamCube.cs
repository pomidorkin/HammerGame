using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyParamCube : MonoBehaviour
{
    [SerializeField] [Range(0, 7)] int band = 0;
    [SerializeField] [Range(0f, 10f)] float animTriggerValue = 1.6f;
    void Update()
    {
        // My Code
        if (AudioPeer.bandBuffer[band] > animTriggerValue)
        {
            //gameObject.GetComponent<Animator>().SetTrigger("CubeJumpTrigger");
            //gameObject.GetComponent<Animator>().Play("Jump");
            gameObject.GetComponent<Animator>().Play("SpearJump");
        }

       /* Debug.Log("bandBuffer[0]; Value: "  + AudioPeer.bandBuffer[0]);
        Debug.Log("bandBuffer[1]; Value: " + AudioPeer.bandBuffer[1]);
        Debug.Log("bandBuffer[2]; Value: " + AudioPeer.bandBuffer[2]);
        Debug.Log("bandBuffer[3]; Value: " + AudioPeer.bandBuffer[3]);
        Debug.Log("bandBuffer[4]; Value: " + AudioPeer.bandBuffer[4]);*/

    }
}