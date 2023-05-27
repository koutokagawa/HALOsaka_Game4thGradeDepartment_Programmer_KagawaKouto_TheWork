using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectButton : MonoBehaviour
{
    #region//�C���X�y�N�^�[�Őݒ肷��
    [Header("�V�[����")] public string scenename;
    #endregion
    [SerializeField] private GameObject[] objectsToInvalidate;


    public void ButtonClicked(UnityEngine.UI.Button button)
    {
        StartCoroutine(LoadScenesAsync());        //�V�[����ǂݍ���
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
