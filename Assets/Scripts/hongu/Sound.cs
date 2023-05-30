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
        //ComponentÇéÊìæ
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // ç∂
        if (Input.GetKeyDown("joystick button 4"))
        {
            audioSource.PlayOneShot(sound1);
        }
        // âE
        if (Input.GetKeyDown("joystick button 5"))
        {
            audioSource.PlayOneShot(sound2);
        }
        // è„
        if (Input.GetKeyDown("joystick button 6"))
        {
            audioSource.PlayOneShot(sound3);
        }
        // â∫
        if (Input.GetKeyDown("joystick button 7"))
        {
            audioSource.PlayOneShot(sound4);
        }
    }

}