using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildSetVer2 : MonoBehaviour
{
    private string Hitobj;
    private string Setobj;

    // 1フレーム前の位置
    Vector3 Pos;
    public CapsuleCollider col;
    public PlayerUp character;
    public ShaftManagerVer2 Shaft;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "RayHitObjTopUnder")
        {
            this.gameObject.transform.parent = other.gameObject.transform;
        }
    }

    void Start()
    {

    }

    void FixedUpdate()
    {
        // 左スティック
        float LstickX = Input.GetAxis("LstickX");
        float LstickY = Input.GetAxis("LstickY");

        // 全てのページが動いていない場合
        if (Shaft.GetComponent<ShaftManagerVer2>().pageMove1 == false
             && Shaft.GetComponent<ShaftManagerVer2>().pageMove2 == false)
        {
            // プレイヤーが釣り上げられていない場合、当たり判定を付ける
            if (character.GetComponent<PlayerUp>().MaxUp == false)
            {
                if ((LstickX != 0) || (LstickY != 0))
                {
                    col.enabled = true;
                }
            }
            // プレイヤーが釣り上げられたら子オブジェクトから外す
            else
            {
                this.gameObject.transform.parent = null;
            }
        }
        // どれかのページが動いたら当たり判定を切る
        else
        {
            col.enabled = false;
        }
    }
}
