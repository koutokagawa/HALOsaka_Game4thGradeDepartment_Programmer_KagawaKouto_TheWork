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
#if UNITY_EDITOR    //UnityEngine�ł̎��s�Ȃ�

        //�Đ����[�h����������
        UnityEditor.EditorApplication.isPlaying = false;

#else               //UnityEditor�ł̎��s�łȂ���΁i���r���h��j�Ȃ�
        //�A�v���P�[�V�������I������
        Application.Quit();

#endif
    }
}
