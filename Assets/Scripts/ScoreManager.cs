using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameObject noHitText;
    [SerializeField] Canvas canvas;
    [SerializeField] Camera camera;

    // Combo
    [SerializeField] GameObject comboGameObject;
    [SerializeField] TMP_Text comboText;
    private bool comboEnabled = false;
    private int comboCounter = 0;
    [SerializeField] ITweenCombo tweenCombo;

    public void UpdateScore(int val)
    {
        if (comboCounter == 0)
        {
            score += val;
        }
        else if (comboCounter > 0)
        {
            score += val * comboCounter;
        }
        scoreText.text = "Очки: " + score.ToString();
    }

    public int GetScore()
    {
        return score;
    }

    public void InstantiateNoHitText()
    {
        Vector2 pos = new Vector2(Random.Range(2.9f, 3.5f), Random.Range(-0.65f, 0.75f));
        var newText = Instantiate(noHitText, pos, Quaternion.identity);
        newText.transform.SetParent(canvas.transform, false);
        //ConvertWorldSpaceToCanvas(newText.GetComponent<RectTransform>(), pos);
        UpdateComboText(false);
    }

    public void UpdateComboText(bool hit)
    {
        if (!comboEnabled && hit)
        {
            comboCounter++;
            comboGameObject.SetActive(true);
            comboText.text = "Чётко";
            comboEnabled = true;
            tweenCombo.PulseEffect();
        }
        else if (comboEnabled && hit)
        {
            comboCounter++;
            if (comboCounter > 5 && comboCounter < 10)
            {
                comboText.text = "Комбо! х" + comboCounter;
            }
            else if (comboCounter > 10 && comboCounter < 15)
            {
                comboText.text = "Невероятно! х" + comboCounter;
            }
            else if (comboCounter > 15 && comboCounter < 25)
            {
                comboText.text = "Мега Комбо! х" + comboCounter;
            }
            else if (comboCounter > 25 && comboCounter < 50)
            {
                comboText.text = "Ультра Комбо! х" + comboCounter;
            }
            else if (comboCounter > 50)
            {
                comboText.text = "0_0 х" + comboCounter;
            }
            tweenCombo.PulseEffect();
        }
        else if (comboEnabled && !hit)
        {
            comboCounter = 0;
            comboGameObject.SetActive(false);
            comboEnabled = false;
        }
    }

    private void ConvertWorldSpaceToCanvas(RectTransform UI_Element, Vector2 pos)
    {
        GameObject WorldObject;
        RectTransform CanvasRect = canvas.GetComponent<RectTransform>();
        Vector2 ViewportPosition = camera.WorldToViewportPoint(pos);
        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * 0.5f)));
        UI_Element.transform.SetParent(CanvasRect);
        UI_Element.position = WorldObject_ScreenPosition;
    }
}
