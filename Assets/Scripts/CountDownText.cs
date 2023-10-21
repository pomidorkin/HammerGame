using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownText : MonoBehaviour
{
    [SerializeField] TMP_Text countDownText;
    private float countDown;
    int i = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        countDown += Time.deltaTime;
        if (countDown >= 1f && i < 3)
        {
            countDown = 0;
            i++;
            countDownText.text = i.ToString();
            iTween.ScaleTo(gameObject, iTween.Hash("x", 2, "y", 2, "time", .2, "easetype", iTween.EaseType.easeInOutBack, "oncomplete", "goBackToOriginal"));
        }
        else if (countDown >= 1f && i >= 3)
        {
            gameObject.SetActive(false);
        }
    }

    private void goBackToOriginal()
    {
        iTween.ScaleTo(gameObject, iTween.Hash("x", 1, "y", 1, "time", .2, "easetype", iTween.EaseType.easeOutQuart));
    }
}
