using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationReverse : MonoBehaviour
{
    private Animator animator;
    private Gamepad gamepad;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        gamepad = Gamepad.current;
    }

    // Update is called once per frame
    void Update()
    {
        if (gamepad.buttonSouth.wasPressedThisFrame)
        {
            // Switch the sign of the speed value to play the animation in reverse
            animator.SetFloat("Speed", -Mathf.Abs(animator.GetFloat("Speed")));
        }
    }
}
