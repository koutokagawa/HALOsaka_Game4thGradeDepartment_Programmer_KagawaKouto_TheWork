using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cursolstageselect : MonoBehaviour
{
    public List<Vector3> destinationPositions;
    private int currentDestinationIndex;

    public GameObject stage1book;
    public GameObject stage2book;
    public GameObject stage3book;
    public GameObject stage4book;
    public GameObject stage5book;

    private Animator stage1bookAnimator;
    private Animator stage2bookAnimator;
    private Animator stage3bookAnimator;
    private Animator stage4bookAnimator;
    private Animator stage5bookAnimator;

    void Start()
    {
        destinationPositions = new List<Vector3>
        {
            new Vector3(-54.5f, 13.8f, 194.4f),  // stage1bookの位置
            new Vector3(28.7f, 13.8f, 194.4f),   // stage2bookの位置
            new Vector3(-22.5f, -18.6f, 194.4f), // stage3bookの位置
            new Vector3(21.3f, -18.6f, 194.4f),  // stage4bookの位置
            new Vector3(32.8f, -51.9f, 194.4f)   // stage5bookの位置
        };

        stage1bookAnimator = stage1book.GetComponent<Animator>();
        stage2bookAnimator = stage2book.GetComponent<Animator>();
        stage3bookAnimator = stage3book.GetComponent<Animator>();
        stage4bookAnimator = stage4book.GetComponent<Animator>();
        stage5bookAnimator = stage5book.GetComponent<Animator>();

        // Disable all animators at start
        DisableAllAnimators();
    }

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        // Check if the right or left button on the D-pad or the arrow keys were pressed this frame
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame || Gamepad.current.dpad.right.wasPressedThisFrame)
        {
            // Move to the next position
            currentDestinationIndex = (currentDestinationIndex + 1) % destinationPositions.Count;
            this.gameObject.transform.position = destinationPositions[currentDestinationIndex];
        }

        if (Keyboard.current.leftArrowKey.wasPressedThisFrame || Gamepad.current.dpad.left.wasPressedThisFrame)
        {
            // Move to the previous position
            currentDestinationIndex--;
            if (currentDestinationIndex < 0)
            {
                currentDestinationIndex = destinationPositions.Count - 1;
            }
            this.gameObject.transform.position = destinationPositions[currentDestinationIndex];
        }

        // If A button or Enter key is pressed, enable the correct animator depending on the current position
        if (Keyboard.current.enterKey.wasPressedThisFrame || Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            EnableCorrectAnimator();
        }
    }

    void DisableAllAnimators()
    {
        stage1bookAnimator.enabled = false;
        stage2bookAnimator.enabled = false;
        stage3bookAnimator.enabled = false;
        stage4bookAnimator.enabled = false;
        stage5bookAnimator.enabled = false;
    }

    void EnableCorrectAnimator()
    {
        DisableAllAnimators();

        switch (currentDestinationIndex)
        {
            case 0:
                stage1bookAnimator.enabled = true;
                break;
            case 1:
                stage2bookAnimator.enabled = true;
                break;
            case 2:
                stage3bookAnimator.enabled = true;
                break;
            case 3:
                stage4bookAnimator.enabled = true;
                break;
            case 4:
                stage5bookAnimator.enabled = true;
                break;
        }
    }
}
