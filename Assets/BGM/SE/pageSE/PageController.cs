using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageController : MonoBehaviour
{
    public AudioSource audioSource; // 効果音再生用のAudioSource

    private bool isFlipping = false; // ページめくり中かどうかを示すフラグ

    // ページめくりの開始をトリガーする関数
    public void StartFlipping()
    {
        if (!isFlipping)
        {
            // ページめくりの開始処理を実行

            // ページめくりの開始時に効果音を再生
            audioSource.Play();

            isFlipping = true;
        }
    }

    // ページめくりの終了をトリガーする関数
    public void StopFlipping()
    {
        if (isFlipping)
        {
            // ページめくりの終了処理を実行

            isFlipping = false;
        }
    }
}