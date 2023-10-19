using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleController : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] GameObject missText;
    [SerializeField] Canvas canvas;
    [SerializeField] Camera camera;
    [SerializeField] GameObject hitEffect;

    public delegate void KeyPressedAction();
    public event KeyPressedAction OnKeyPressed;
    bool nailHit = false;
    private void Awake()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            OnKeyPressed();
            Debug.Log("Key pressed!");
        }
    }

    public void CheckIfNail()
    {
        if (nailHit)
        {
            nailHit = false;
            scoreManager.UpdateScore(10);
            scoreManager.UpdateComboText(true);
        }
        else
        {
            scoreManager.UpdateScore(-10);
            InstantiateMissText();
            Debug.Log("Miss!");
            scoreManager.UpdateComboText(false);
        }
    }

    public void SetHit(bool val)
    {
        nailHit = val;
    }

    private void InstantiateMissText()
    {
        Vector2 pos = new Vector2(Random.Range(-1.0f, 0.4f), Random.Range(-0.65f, 0.75f));
        var newText = Instantiate(missText, pos, Quaternion.identity);
        newText.transform.SetParent(canvas.transform, false);
        //ConvertWorldSpaceToCanvas(newText.GetComponent<RectTransform>(), pos);
    }

    private void ConvertWorldSpaceToCanvas(RectTransform UI_Element, Vector2 pos)
    {
        GameObject WorldObject;
        RectTransform CanvasRect = canvas.GetComponent<RectTransform>();
        Vector2 ViewportPosition = camera.WorldToViewportPoint(pos);
        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * 0.5f)));
        UI_Element.position = WorldObject_ScreenPosition;
    }

    public void SetHitEffectActive()
    {
        hitEffect.SetActive(true);
    }

    public void DisableHitEffect()
    {
        hitEffect.SetActive(false);
    }
}
