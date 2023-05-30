using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MoveObj3 : MonoBehaviour
{
    Vector3 velocity;

    [Header("characterオブジェクトを入れる")] public GameObject character;

    private Rigidbody rb = null;

    [Header("Rigidbodyのオンオフ切り替えを有効にする場所")]
    public bool ObjectPosL = false;
    public bool ObjectPosR = false;

    private bool moveObjHitL = false;
    private bool moveObjHitR = false;

    private bool book2LRHit = false;

    private bool pageHit = false;

    public bool flameHit = false;

    private bool moveLineHit = false;

    private Material material;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "flame")
        {
            flameHit = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {


        if (ObjectPosL == true)
        {
            if (other.gameObject.tag == "bookL")
            {
                moveObjHitL = true;
            }
        }

        if (ObjectPosR == true)
        {
            if (other.gameObject.tag == "bookR")
            {
                moveObjHitR = true;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "moveLine")
        {
            moveLineHit = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "moveLine")
        {
            moveLineHit = false;
        }



        if (ObjectPosL == true)
        {
            if (other.gameObject.tag == "bookL")
            {
                moveObjHitL = false;
            }
        }

        if (ObjectPosR == true)
        {
            if (other.gameObject.tag == "bookR")
            {
                moveObjHitR = false;
            }
        }
    }

    void Start()
    {
        material = GetComponent<Material>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // material.DissolveThreshold = 0.01f;

        MOVE();
    }

    public void MOVE()
    {
        // 速度を保存
        //velocity = rb.velocity;

        float RstickX = Input.GetAxis("RstickX");

        // 燃えるオブジェクトに当たっていない場合
        if (flameHit == false)
        {
            // プレイヤーが地面にいるのか判定     falseなら地面にいる
            if (character.GetComponent<RayPlayer3>().DownCheck == true)
            {
                // 移動可能なオブジェクトに当たっている間は動ける
                if (moveLineHit == true)
                {
                    // moveObjHitのタグが付いたオブジェクトに当たると
                    // ページに固定している状態を解除して動くようにする
                    if (moveObjHitL == true || moveObjHitR == true)
                    {
                        if (RstickX != 0)
                        {
                            rb.constraints = RigidbodyConstraints.FreezeAll;
                        }
                        else
                        {
                            rb.constraints = RigidbodyConstraints.FreezePositionZ
                                          | RigidbodyConstraints.FreezeRotationX
                                          | RigidbodyConstraints.FreezeRotationY;
                        }
                    }
                    else
                    {
                        rb.constraints = RigidbodyConstraints.FreezeAll;
                    }
                }
                else
                {
                    rb.constraints = RigidbodyConstraints.FreezeAll;
                }
            }
            else
            {
                rb.constraints = RigidbodyConstraints.FreezeAll;
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    
}