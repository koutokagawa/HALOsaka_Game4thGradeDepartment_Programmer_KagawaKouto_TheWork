using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;


public class ActivateOnCollision : MonoBehaviour
{
    [Header("���[�h����V�[����")]
    public string sceneName;

    // �L��������I�u�W�F�N�g���C���X�y�N�^����A�T�C���ł���悤�ɂ��邽�߂̕ϐ�
    //public GameObject objectToActivate;

    // ����̃I�u�W�F�N�g�ƏՓ˂����Ƃ��ɃI�u�W�F�N�g��L�������邽�߂̃^�O
    public string targetTag = "Player";

    private void OnCollisionEnter(Collision collision)
    {
        // �Փ˂����I�u�W�F�N�g�̃^�O���w�肵���^�O�ƈ�v����ꍇ
        if (collision.gameObject.CompareTag(targetTag))
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }
    }
}
