using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class au : MonoBehaviour
{
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlaySE();
    }

    private void Update()
    {
        if (Input.GetKeyDown("joystick button 8"))
        {
            PlaySE();
        }
    }

    public void PlaySE()
    {
        audioSource.Play();
    }
}
