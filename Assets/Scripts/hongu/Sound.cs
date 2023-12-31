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
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 左
        if (Input.GetKeyDown("joystick button 4"))
        {
            audioSource.PlayOneShot(sound1);
        }
        // 右
        if (Input.GetKeyDown("joystick button 5"))
        {
            audioSource.PlayOneShot(sound2);
        }
        // 上
        if (Input.GetKeyDown("joystick button 6"))
        {
            audioSource.PlayOneShot(sound3);
        }
        // 下
        if (Input.GetKeyDown("joystick button 7"))
        {
            audioSource.PlayOneShot(sound4);
        }
    }

}