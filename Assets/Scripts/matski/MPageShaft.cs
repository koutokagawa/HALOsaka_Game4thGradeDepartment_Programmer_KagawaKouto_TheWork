using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class MPageShaft : MonoBehaviour
{

    public bool isUp;//ページを動かしているかどうかの判定フラグ
    public GameObject hitcheck;//他オブジェクトを参照する

    void Start()
    {
        isUp = false;//最初は動いてないのでfalseを入れる
        hitcheck = GameObject.Find("page");//参照するオブジェクトを指定する
    }

    void Update()
    {
        Rotation();
        
    }



    public void Rotation()
    {
        // 左右キー入力に応じて回転速度を決定
        float speed = 0.0f;

        //bookhitLがtrue(ページの端に当たっている)ときとfalse(当っていない)時でそれぞれ別の判定を行う
        if (hitcheck.GetComponent<MObjectMove>().ishitL == false)//MObject ScriptのishitLを参照する
        {

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                speed += 45.0f;
                isUp = true;//ページが動いているのでtrueにする
            }
            else
            {
                isUp = false;//ページが動いてないのでfalseにする
            }
        }
        else if (hitcheck.GetComponent<MObjectMove>().ishitL == true)//MObjectのishitLを参照する
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                speed += 0.0f;
                isUp = false;//ページが動いてないのでfalse
            }
        }

        //bookhitRがtrue(ページの端に当たっている)ときとfalse(当っていない)時でそれぞれ別の判定を行う
        if (hitcheck.GetComponent<MObjectMove>().ishitR == false)//MObject ScriptのishitRを参照する
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                speed += -45.0f;
                isUp = true;//ページが動いているのでtrueにする
            }
            else
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    isUp = true;//ページが動いているのでtrueにする
                }
                else
                {
                    isUp = false;//ページが動いてないのでfalse
                }
                   
            }
        }
        else if (hitcheck.GetComponent<MObjectMove>().ishitR == true)//MObject ScriptのishitRを参照する
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                speed += 0.0f;
                isUp = false;//ページが動いてないのでfalse
            }
        }

            // Y軸(Vector3.up)周りを１フレーム分の角度だけ回転させるQuaternionを作成
            Quaternion rot = Quaternion.AngleAxis(speed * Time.deltaTime, Vector3.forward);

        // 元の回転値と合成して上書き
        transform.localRotation = rot * transform.localRotation;
    }

}

