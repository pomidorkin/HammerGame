using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITweenCombo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        iTween.RotateTo(gameObject, iTween.Hash("z", 25, "time", 1, "looptype", "pingpong", "easetype", iTween.EaseType.easeInOutCubic));
    }

    public void PulseEffect()
    {
        iTween.ScaleTo(gameObject, iTween.Hash("x", 2, "y", 2, "time", .2f, "oncomplete", "goBackToOriginal"));
    }

private void goBackToOriginal()
{
    iTween.ScaleTo(gameObject, iTween.Hash("x", 1, "y", 1, "time", .2));
}
}
