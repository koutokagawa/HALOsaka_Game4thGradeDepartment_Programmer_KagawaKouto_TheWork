using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame_SE : MonoBehaviour
{

    public GameObject targetObject;
    public AudioClip soundEffect;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }



    private void Update()
    {


        if (targetObject != null && !audioSource.isPlaying)
        {
            bool isActive = targetObject.activeSelf;
            // �A�N�e�B�u���ǂ����ɉ����ď������s��
            if (isActive)
            {
                // �I�u�W�F�N�g�����݂��Ă���ASE���Đ�����Ă��Ȃ��ꍇ
                PlaySoundEffect();
            }

            else
            {
                Debug.Log("�I�u�W�F�N�g�͔�A�N�e�B�u�ł�");
            }
        }
    }

    private void PlaySoundEffect()
    {
        audioSource.clip = soundEffect;
        audioSource.Play();
    }
}