using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_Test2 : MonoBehaviour
{
    public AudioSource ad;
    public RayPlayer RP;
    public AudioSource audioSource; // �I�[�f�B�I�\�[�X�R���|�[�l���g���i�[����ϐ�
    public AudioClip soundEffect; // ���ʉ��t�@�C�����i�[����ϐ�

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

        //if (!(-0.01f <= LstickX && LstickX <= 0.01f) || !(-0.01f <= LstickY && LstickY <= 0.01f))

        if (transform.position.y > 10.0f)
        {
            if (!audioSource.isPlaying) // ���ʉ����Đ�����Ă��Ȃ��ꍇ�̂ݍĐ�����
            {
                audioSource.PlayOneShot(soundEffect); // ���ʉ����Đ�
            }
        }
    }

}