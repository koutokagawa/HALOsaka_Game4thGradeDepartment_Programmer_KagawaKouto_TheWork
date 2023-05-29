using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    public Animator animatorToEnable; // Set this in the inspector

    private void Update()
    {
        if (Gamepad.current != null && Gamepad.current.startButton.wasPressedThisFrame)
        {
            EnableAnimator();
        }
    }

    private void EnableAnimator()
    {
        if (animatorToEnable != null)
        {
            animatorToEnable.enabled = true;
        }
    }
}
