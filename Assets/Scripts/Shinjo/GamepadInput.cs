using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamepadInput : MonoBehaviour
{
    public Animator animator; // Animator component
    public string reverseAnimationName; // Reverse Animation name
    public string forwardAnimationName; // Forward Animation name

    private Parents parentsScript; // Parents script

    private void Awake()
    {
        parentsScript = GetComponent<Parents>(); // Getting Parents script component
    }

    void Update()
    {
        if (Gamepad.current.buttonSouth.wasPressedThisFrame) // B button in Xbox controller, Cross button in PlayStation controller
        {
            parentsScript.enabled = true; // Enable Parents script

            if (animator != null)
            {
                StartCoroutine(PlayReverseThenForward());
            }
        }
    }

    IEnumerator PlayReverseThenForward()
    {
        animator.Play(reverseAnimationName, 0, 1); // Start Reverse animation from the end
        animator.speed = -1; // Reverse play

        // Wait until the animation is finished
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0);

        animator.speed = 1; // Forward play
        animator.Play(forwardAnimationName); // Start Forward animation from the beginning

        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1); // Wait for Forward animation to finish
    }
}
