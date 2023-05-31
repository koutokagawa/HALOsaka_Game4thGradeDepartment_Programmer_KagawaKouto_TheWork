using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageController : MonoBehaviour
{
    public AudioSource audioSource; // ���ʉ��Đ��p��AudioSource

    private bool isFlipping = false; // �y�[�W�߂��蒆���ǂ����������t���O

    // �y�[�W�߂���̊J�n���g���K�[����֐�
    public void StartFlipping()
    {
        if (!isFlipping)
        {
            // �y�[�W�߂���̊J�n���������s

            // �y�[�W�߂���̊J�n���Ɍ��ʉ����Đ�
            audioSource.Play();

            isFlipping = true;
        }
    }

    // �y�[�W�߂���̏I�����g���K�[����֐�
    public void StopFlipping()
    {
        if (isFlipping)
        {
            // �y�[�W�߂���̏I�����������s

            isFlipping = false;
        }
    }
}