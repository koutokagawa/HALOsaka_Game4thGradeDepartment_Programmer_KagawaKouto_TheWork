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
        bool isActive = targetObject.activeSelf;


        if (targetObject != null && !audioSource.isPlaying)
        {
            // アクティブかどうかに応じて処理を行う
            if (isActive)
            {
                // オブジェクトが存在しており、SEが再生されていない場合
                PlaySoundEffect();
            }
            //else
            //{
            //    Debug.Log("オブジェクトは非アクティブです");
            //}
        }
    }

    private void PlaySoundEffect()
    {
        audioSource.clip = soundEffect;
        audioSource.Play();
    }
}