using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_Test2 : MonoBehaviour
{
    public AudioSource ad;
    public RayPlayer2 RP;
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

        //if (!(-0.01f <= LstickX && LstickX <= 0.01f) || !(-0.01f <= LstickY && LstickY <= 0.01f))
        if (RP.NowMoveflg)
        {

            if (RP.DownCheck != true)
            {
                if (ad.isPlaying == false)
                {
                    audioSource.PlayOneShot(soundEffect);
                }
            }
        }

        if (Input.GetKeyDown("joystick button 0"))
        {
            if (ad.isPlaying == false) // 効果音が再生されていない場合のみ再生する
            {
                audioSource.PlayOneShot(soundEffect2); // 効果音を再生
            }
        }
    }
}