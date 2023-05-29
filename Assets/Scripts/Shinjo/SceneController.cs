using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    private Gamepad gamepad;
    private int currentSceneIndex = 0;

    public List<string> sceneNames = new List<string>();
    private AsyncOperation asyncOperation;
    public Image fadeImage; // Fade effect image

    void Start()
    {
        gamepad = Gamepad.current;
        fadeImage.gameObject.SetActive(false); // initially invisible
    }

    void Update()
    {
        if (gamepad == null)
        {
            return;
        }

        if (gamepad.buttonSouth.wasPressedThisFrame)
        {
            StartCoroutine(LoadSceneAsync());
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

    private IEnumerator LoadSceneAsync()
    {
        string sceneName = sceneNames[currentSceneIndex];

        fadeImage.gameObject.SetActive(true); // make the fade image visible
        Color fadeColor = fadeImage.color;
        float fadeDuration = 1f; // fade duration
        float fadeTimer = 0f;

        // Fade out
        while (fadeTimer < fadeDuration)
        {
            fadeTimer += Time.deltaTime;
            fadeColor.a = Mathf.Lerp(0, 1, fadeTimer / fadeDuration);
            fadeImage.color = fadeColor;
            yield return null;
        }

        asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}
