using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionChangedSE : MonoBehaviour
{
    public AudioSource audioSource; // ���ʉ��Đ��p��AudioSource
    private Vector3 previousPosition; // �O��̃|�W�V�����̕ۑ��p�ϐ�

    private void Start()
    {
        previousPosition = transform.position; // �����|�W�V�����̕ۑ�
    }

    private void Update()
    {
        if (transform.position != previousPosition)
        {
            // �|�W�V�������ύX���ꂽ�ꍇ�Ɍ��ʉ����Đ�
            audioSource.Play();

            // �|�W�V�����̕ύX�����m������A�O��̃|�W�V�������X�V
            previousPosition = transform.position;
        }
    }
}