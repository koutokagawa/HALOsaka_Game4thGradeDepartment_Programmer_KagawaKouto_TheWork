using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageTest : MonoBehaviour
{
    public AudioSource ad;
    public ShaftManager2 SM2;
    public AudioSource audioSource; // �I�[�f�B�I�\�[�X�R���|�[�l���g���i�[����ϐ�
    public AudioClip soundEffect; // ���ʉ��t�@�C�����i�[����ϐ�
    public AudioClip soundEffect2; // ���ʉ��t�@�C�����i�[����ϐ�


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // �I�[�f�B�I�\�[�X�R���|�[�l���g���擾
    }

    // Update is called once per frame
    void Update()
    {
        //float LstickX = Input.GetAxis("LstickX");
        //float LstickY = Input.GetAxis("LstickY");


        if (SM2.pageMove1 == true)
        {

            if (ad.isPlaying == false)
            {
                audioSource.PlayOneShot(soundEffect);
            }

        }

    }
}