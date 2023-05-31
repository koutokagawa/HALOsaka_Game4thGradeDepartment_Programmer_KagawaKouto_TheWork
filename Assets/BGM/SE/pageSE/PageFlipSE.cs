using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageFlipSE : MonoBehaviour
{
    public AudioSource audioSource; // 効果音再生用のAudioSource

    // ページめくりアニメーションの進捗を監視する関数
    public void UpdateFlipProgress(float progress)
    {
        if (progress >= 0.5f && !audioSource.isPlaying)
        {
            // 効果音を再生する条件を設定します
            audioSource.Play();
        }
    }
}
