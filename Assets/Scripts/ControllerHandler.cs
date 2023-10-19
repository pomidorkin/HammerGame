using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerHandler : MonoBehaviour
{
    [SerializeField] SimpleController controller;
    [SerializeField] Animator animator;

    private void OnEnable()
    {
        controller.OnKeyPressed += KeyPressedHandler;
    }

    private void OnDisable()
    {
        controller.OnKeyPressed -= KeyPressedHandler;
    }

    private void KeyPressedHandler()
    {
        animator.Play("Hit");
    }
}
