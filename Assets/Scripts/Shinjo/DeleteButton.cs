using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteButton : MonoBehaviour
{

    public void ButtonClicked(UnityEngine.UI.Button button)
    {
        GameEnd();
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
