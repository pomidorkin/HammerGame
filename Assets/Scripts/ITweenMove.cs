using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITweenMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        iTween.MoveTo(gameObject, iTween.Hash("y", 7, "time", 4, "islocal", true));
        StartCoroutine(DestroyText());
    }

    private IEnumerator DestroyText()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
