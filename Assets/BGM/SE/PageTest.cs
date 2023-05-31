using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageTest : MonoBehaviour
{
    public AudioSource ad;
    public ShaftManager2 SM2;
    public AudioSource audioSource; // オーディオソースコンポーネントを格納する変数
    public AudioClip soundEffect; // 効果音ファイルを格納する変数
    public AudioClip soundEffect2; // 効果音ファイルを格納する変数


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // オーディオソースコンポーネントを取得
    }

    // Update is called once per frame
    void Update()
    {
        //float LstickX = Input.GetAxis("LstickX");
        //float LstickY = Input.GetAxis("LstickY");


        if (SM2.pageMove1 == true)
        {

            if (ad.isPlaying == false)
            {
                audioSource.PlayOneShot(soundEffect);
            }

        }

    }
}