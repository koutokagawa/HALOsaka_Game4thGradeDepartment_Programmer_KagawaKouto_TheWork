using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public string sceneToLoad;  // ロードするシーン
    public float fadeDuration = 1f;  // フェードアウトの持続時間
    public Image fadePanel;  // フェードアウトに使用するパネルのImageコンポーネント

    private bool startFade = false;  // フェードアウトを開始するかどうかを制御するフラグ

    private void Start()
    {
        startFade= true;
    }

    void Update()
    {
        // startFadeフラグがtrueに設定されている場合、フェードアウトとシーンのロードを開始します
        if (startFade)
        {
            StartCoroutine(FadeAndLoadScene(sceneToLoad));
            startFade = false;  // フェードアウトが複数回開始されないようにフラグをリセットします
        }
    }

    // フェードアウトとシーンのロードを行うコルーチン
    IEnumerator FadeAndLoadScene(string sceneName)
    {
        // パネルの透明度を徐々に0から1に変化させることでフェードアウトの効果を作成します
        float fadeSpeed = 1f / fadeDuration;
        Color c = fadePanel.color;
        c.a = 0f;  // フェードアウト開始時はパネルは透明にします
        for (float t = 0f; t < 1f; t += Time.deltaTime * fadeSpeed)
        {
            c.a = t;
            fadePanel.color = c;
            yield return null;
        }
        c.a = 1f;  // フェードアウト終了時はパネルは不透明にします
        fadePanel.color = c;

        // フェードアウトが完了した後に指定されたシーンをロードします
        SceneManager.LoadScene(sceneName);
    }
}
