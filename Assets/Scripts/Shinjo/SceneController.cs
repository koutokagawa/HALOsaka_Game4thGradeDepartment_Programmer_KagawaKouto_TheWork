using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private Gamepad gamepad;
    private int currentSceneIndex = 0;

    public List<string> sceneNames = new List<string>();

    void Start()
    {
        gamepad = Gamepad.current;


    }

    void Update()
    {
        if (gamepad == null)
        {
            return;
        }

        if (gamepad.buttonSouth.wasPressedThisFrame)
        {
            LoadScene();
        }

        if (gamepad.dpad.left.wasPressedThisFrame)
        {
            currentSceneIndex = Mathf.Max(currentSceneIndex - 1, 0);
        }

        if (gamepad.dpad.right.wasPressedThisFrame)
        {
            currentSceneIndex = Mathf.Min(currentSceneIndex + 1, sceneNames.Count - 1);
        }
    }

    private void LoadScene()
    {
        string sceneName = sceneNames[currentSceneIndex];
        SceneManager.LoadScene(sceneName);
    }
}