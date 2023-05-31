using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionChangedSE : MonoBehaviour
{
    public AudioSource audioSource; // 効果音再生用のAudioSource
    private Vector3 previousPosition; // 前回のポジションの保存用変数

    private void Start()
    {
        previousPosition = transform.position; // 初期ポジションの保存
    }

    private void Update()
    {
        if (transform.position != previousPosition)
        {
            // ポジションが変更された場合に効果音を再生
            audioSource.Play();

            // ポジションの変更を検知した後、前回のポジションを更新
            previousPosition = transform.position;
        }
    }
}