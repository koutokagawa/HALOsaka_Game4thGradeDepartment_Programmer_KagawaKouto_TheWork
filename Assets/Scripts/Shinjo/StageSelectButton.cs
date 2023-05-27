using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectButton : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("シーン名")] public string scenename;
    #endregion
    [SerializeField] private GameObject[] objectsToInvalidate;


    public void ButtonClicked(UnityEngine.UI.Button button)
    {
        StartCoroutine(LoadScenesAsync());        //シーンを読み込む
    }
    IEnumerator LoadScenesAsync()
    {

        AsyncOperation loadScene1 = SceneManager.LoadSceneAsync(scenename, LoadSceneMode.Additive);

        yield return new WaitUntil(() => loadScene1.isDone);
        foreach (GameObject obj in objectsToInvalidate)
        {
            obj.SetActive(false);
        }
    }
}
