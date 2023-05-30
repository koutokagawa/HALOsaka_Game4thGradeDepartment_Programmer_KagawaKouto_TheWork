using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tes : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
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