using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class PageShaft : MonoBehaviour
{
    public bool isUp;
    #region//インスペクターで設定する
    [Header("pageを入れる")] public Pagehit hitcheck;
    [Header("headcheckを入れる")] public PlayerUp upChrck;

    [Header("characterオブジェクトを入れる")] public GameObject character;
    #endregion

    float rotation = 0.0f;

    private bool tmp;

    private int cnt = 0;

    private bool checkA = false;
    private bool checkL = false;
    private bool checkR = false;

    public AudioSource audioSource; // オーディオソースコンポーネントを格納する変数
    public AudioClip soundEffect; // 効果音ファイルを格納する変数
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // オーディオソースコンポーネントを取得
    }

    void Update()
    {
        float Trigger = Input.GetAxis("LRtrigger");

        if (character.GetComponent<RayPlayer>().DownCheck == true)
        {
            if (Input.GetKeyDown("joystick button 0"))
            {
                enabled = false;
            }
        }

        if (Input.GetKeyDown("joystick button 4"))
        {
            checkL = true;
            checkR = false;
        }
        else if (Input.GetKeyDown("joystick button 5"))
        {
            checkL = false;
            checkR = true;
        }
    }

    void FixedUpdate()
    {
        // プレイヤーが地面にいるのか判定     falseなら地面にいる
        if (character.GetComponent<RayPlayer>().DownCheck == false && upChrck.GetComponent<PlayerUp>().MaxUp == false)
        {
            RotationB();
        }

        // プレイヤーが釣り上げられているのか    falseなら地面にいる
        else if (upChrck.GetComponent<PlayerUp>().MaxUp == true)
        {
            RotationA();
        }
        rotation = 0.0f;
    }

    // ゆっくりめくる
    public void RotationA()
    {
        // 右スティック        
        float RstickX = Input.GetAxis("RstickX");

        // 右スティックの倒す角度でページの回転速度を変える
        // 右にステックを倒した場合
        if (hitcheck.GetComponent<Pagehit>().ishitL == false)
        {
            if (RstickX == 1.0f)
            {
                rotation += 100.0f;
            }
            else if (RstickX > 0.8)
            {
                rotation += 40.0f;
            }
            else if (RstickX > 0.6)
            {
                rotation += 30.0f;
            }
            else if (RstickX > 0.4)
            {
                rotation += 10.0f;
            }
            else if (RstickX > 0.2)
            {
                rotation += 5.0f;
            }
        }


        // 左にステックを倒した場合
        if (hitcheck.GetComponent<Pagehit>().ishitR == false)
        {
            if (RstickX == -1.0f)
            {
                rotation += -100.0f;
            }
            else if (RstickX < -0.8f)
            {
                rotation += -40.0f;
            }
            else if (RstickX < -0.6f)
            {
                rotation += -30.0f;
            }
            else if (RstickX < -0.4f)
            {
                rotation += -10.0f;
            }
            else if (RstickX < -0.2f)
            {
                rotation += -5.0f;
            }
        }

        // Y軸(Vector3.up)周りを１フレーム分の角度だけ回転させるQuaternionを作成
        Quaternion rot = Quaternion.AngleAxis(rotation * Time.deltaTime, Vector3.forward);
        // 元の回転値と合成して上書き
        transform.localRotation = rot * transform.localRotation;
    }

    // 素早くめくる
    public void RotationB()
    {
        // 右スティックの倒す角度でページの回転速度を変える
        // 右にステックを倒した場合
        if (hitcheck.GetComponent<Pagehit>().ishitL == false)
        {
            if (checkR == true)
            {
                audioSource.PlayOneShot(soundEffect);
                rotation += 400.0f;
            }
        }
        else if (hitcheck.GetComponent<Pagehit>().ishitL == true)
        {
            rotation += 0.0f;
        }

        // 左にステックを倒した場合
        if (hitcheck.GetComponent<Pagehit>().ishitR == false)
        {
            if (checkL == true)
            {
                rotation += -400.0f;
            }
        }
        else if (hitcheck.GetComponent<Pagehit>().ishitR == true)
        {
            rotation += 0.0f;
        }

        // Y軸(Vector3.up)周りを１フレーム分の角度だけ回転させるQuaternionを作成
        Quaternion rot = Quaternion.AngleAxis(rotation * Time.deltaTime, Vector3.forward);

        // 元の回転値と合成して上書き
        transform.localRotation = rot * transform.localRotation;
    }
}