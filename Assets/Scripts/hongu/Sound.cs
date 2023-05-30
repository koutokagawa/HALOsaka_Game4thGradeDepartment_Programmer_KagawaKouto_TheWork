using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
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
        if (Input.GetKeyDown("joystick button 4"))
        {
            audioSource.PlayOneShot(sound1);
        }
        // �E
        if (Input.GetKeyDown("joystick button 5"))
        {
            audioSource.PlayOneShot(sound2);
        }
        // ��
        if (Input.GetKeyDown("joystick button 6"))
        {
            audioSource.PlayOneShot(sound3);
        }
        // ��
        if (Input.GetKeyDown("joystick button 7"))
        {
            audioSource.PlayOneShot(sound4);
        }
    }

}