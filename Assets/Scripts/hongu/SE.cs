using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;

    AudioSource audioSource;

    void Start()
    {
        //Component���擾
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // ��
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            audioSource.PlayOneShot(sound1);
        }
        // �E
        if (Input.GetKey(KeyCode.RightArrow))
        {
            audioSource.PlayOneShot(sound2);
        }
        // ��
        if (Input.GetKey(KeyCode.UpArrow))
        {
            audioSource.PlayOneShot(sound3);
        }
        // ��
        if (Input.GetKey(KeyCode.DownArrow))
        {
            audioSource.PlayOneShot(sound4);
        }
    }

}