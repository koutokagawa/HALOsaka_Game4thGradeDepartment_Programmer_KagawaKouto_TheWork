using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeOutAndLoadScene : MonoBehaviour
{
    public GameObject panelObject;
    public string sceneToLoad;
    public float fadeDuration = 1f;

    public void OnButtonClick()
    {
        StartCoroutine(FadeOutAndLoad());
    }

    IEnumerator FadeOutAndLoad()
    {
        if (panelObject != null)
        {
            // Assumes the panel has a CanvasGroup component
            CanvasGroup canvasGroup = panelObject.GetComponent<CanvasGroup>();

            if (canvasGroup != null)
            {
                // Fade out
                for (float t = 0.0f; t < fadeDuration; t += Time.deltaTime)
                {
                    canvasGroup.alpha = 1.0f - t / fadeDuration;
                    yield return null;
                }

                canvasGroup.alpha = 0f; // Ensure it's fully transparent
            }
        }

        // Load the scene
        SceneManager.LoadScene(sceneToLoad);
    }
}
