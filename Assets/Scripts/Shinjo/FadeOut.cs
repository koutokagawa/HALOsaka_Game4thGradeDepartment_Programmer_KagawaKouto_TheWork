using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public string sceneToLoad;  // ���[�h����V�[��
    public float fadeDuration = 1f;  // �t�F�[�h�A�E�g�̎�������
    public Image fadePanel;  // �t�F�[�h�A�E�g�Ɏg�p����p�l����Image�R���|�[�l���g

    private bool startFade = false;  // �t�F�[�h�A�E�g���J�n���邩�ǂ����𐧌䂷��t���O

    private void Start()
    {
        startFade= true;
    }

    void Update()
    {
        // startFade�t���O��true�ɐݒ肳��Ă���ꍇ�A�t�F�[�h�A�E�g�ƃV�[���̃��[�h���J�n���܂�
        if (startFade)
        {
            StartCoroutine(FadeAndLoadScene(sceneToLoad));
            startFade = false;  // �t�F�[�h�A�E�g��������J�n����Ȃ��悤�Ƀt���O�����Z�b�g���܂�
        }
    }

    // �t�F�[�h�A�E�g�ƃV�[���̃��[�h���s���R���[�`��
    IEnumerator FadeAndLoadScene(string sceneName)
    {
        // �p�l���̓����x�����X��0����1�ɕω������邱�ƂŃt�F�[�h�A�E�g�̌��ʂ��쐬���܂�
        float fadeSpeed = 1f / fadeDuration;
        Color c = fadePanel.color;
        c.a = 0f;  // �t�F�[�h�A�E�g�J�n���̓p�l���͓����ɂ��܂�
        for (float t = 0f; t < 1f; t += Time.deltaTime * fadeSpeed)
        {
            c.a = t;
            fadePanel.color = c;
            yield return null;
        }
        c.a = 1f;  // �t�F�[�h�A�E�g�I�����̓p�l���͕s�����ɂ��܂�
        fadePanel.color = c;

        // �t�F�[�h�A�E�g������������Ɏw�肳�ꂽ�V�[�������[�h���܂�
        SceneManager.LoadScene(sceneName);
    }
}
