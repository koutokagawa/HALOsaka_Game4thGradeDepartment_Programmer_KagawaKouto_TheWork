using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageFlipSE : MonoBehaviour
{
    public AudioSource audioSource; // ���ʉ��Đ��p��AudioSource

    // �y�[�W�߂���A�j���[�V�����̐i�����Ď�����֐�
    public void UpdateFlipProgress(float progress)
    {
        if (progress >= 0.5f && !audioSource.isPlaying)
        {
            // ���ʉ����Đ����������ݒ肵�܂�
            audioSource.Play();
        }
    }
}
