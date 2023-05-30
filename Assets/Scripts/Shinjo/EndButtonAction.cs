using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EndButtonAction : MonoBehaviour
{
    public string sceneToLoad;

    public void ButtonClicked(UnityEngine.UI.Button button)
    {
        SceneManager.LoadScene(sceneToLoad);
    }


    public void GameEnd()
    {
#if UNITY_EDITOR    //UnityEngineでの実行なら

        //再生モードを解除する
        UnityEditor.EditorApplication.isPlaying = false;

#else               //UnityEditorでの実行でなければ（→ビルド後）なら
        //アプリケーションを終了する
        Application.Quit();

#endif
    }
}
