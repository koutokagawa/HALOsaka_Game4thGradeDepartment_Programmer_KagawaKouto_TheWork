using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class MoveObjManager1 : MonoBehaviour
{
    [Header("characterオブジェクトを入れる")] public GameObject character;

    [Header("復活させるオブジェクト")]
    public GameObject Obj;
    public MoveObj1 script;

    [Header("ページが縦向きの状態だとしてのオブジェクトの位置")]
    public bool ObjectPosL = false;
    public bool ObjectPosR = false;

    [Header("このオブジェクトがあるページを選択する")]
    public bool Page1 = false;
    public bool Page2 = false;
    public bool Page3 = false;
    public bool Page4 = false;

    private bool pageHit1 = false;
    private bool pageHit2 = false;
    private bool pageHit3 = false;
    private bool pageHit4 = false;

    public bool hit = false;

    void OnTriggerStay(Collider other)
    {
        if (Obj != null)
        {
            if (ObjectPosL == true)
            {
                if (Page1 == true)
                {
                    if (other.gameObject.tag == "bookL2")
                    {
                        Obj.gameObject.SetActive(false);
                        hit = true;
                    }
                }

                if (Page2 == true)
                {
                    if (other.gameObject.tag == "pagehit2_page1" || other.gameObject.tag == "bookL2")
                    {
                        Obj.gameObject.SetActive(false);
                        hit = true;
                    }
                }

                if (Page3 == true)
                {
                    if (other.gameObject.tag == "pagehit2_page2" || other.gameObject.tag == "bookL2")
                    {
                        Obj.gameObject.SetActive(false);
                        hit = true;
                    }
                }

                if (Page4 == true)
                {
                    if (other.gameObject.tag == "pagehit2_page3" || other.gameObject.tag == "bookL2")
                    {
                        Obj.gameObject.SetActive(false);
                        hit = true;
                    }
                }
            }

            if (ObjectPosR == true)
            {
                if (Page1 == true)
                {
                    if (other.gameObject.tag == "pagehit2_page2" || other.gameObject.tag == "bookR2")
                    {
                        Obj.gameObject.SetActive(false);
                        hit = true;
                    }
                }

                if (Page2 == true)
                {
                    if (other.gameObject.tag == "pagehit2_page3" || other.gameObject.tag == "bookR2")
                    {
                        Obj.gameObject.SetActive(false);
                        hit = true;
                    }
                }

                if (Page3 == true)
                {
                    if (other.gameObject.tag == "pagehit2_page4" || other.gameObject.tag == "bookR2")
                    {
                        Obj.gameObject.SetActive(false);
                        hit = true;
                    }
                }

                if (Page4 == true)
                {
                    if (other.gameObject.tag == "bookR2")
                    {
                        Obj.gameObject.SetActive(false);
                        hit = true;
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (Obj != null)
        {
            if (ObjectPosL == true)
            {
                if (Page1 == true)
                {
                    if (other.gameObject.tag == "bookL2")
                    {
                        hit = false;
                        Obj.gameObject.SetActive(true);
                    }
                }

                if (Page2 == true)
                {
                    if (other.gameObject.tag == "pagehit2_page1" || other.gameObject.tag == "bookL2")
                    {
                        hit = false;
                        Obj.gameObject.SetActive(true);

                    }
                }

                if (Page3 == true)
                {
                    if (other.gameObject.tag == "pagehit2_page2" || other.gameObject.tag == "bookL2")
                    {
                        hit = false;
                        Obj.gameObject.SetActive(true);

                    }
                }

                if (Page4 == true)
                {
                    if (other.gameObject.tag == "pagehit2_page3" || other.gameObject.tag == "bookL2")
                    {
                        hit = false;
                        Obj.gameObject.SetActive(true);

                    }
                }
            }

            if (ObjectPosR == true)
            {
                if (Page1 == true)
                {
                    if (other.gameObject.tag == "pagehit2_page2" || other.gameObject.tag == "bookR2")
                    {
                        hit = false;
                        Obj.gameObject.SetActive(true);

                    }
                }

                if (Page2 == true)
                {
                    if (other.gameObject.tag == "pagehit2_page3" || other.gameObject.tag == "bookR2")
                    {
                        hit = false;
                        Obj.gameObject.SetActive(true);

                    }
                }

                if (Page3 == true)
                {
                    if (other.gameObject.tag == "pagehit2_page4" || other.gameObject.tag == "bookR2")
                    {
                        hit = false;
                        Obj.gameObject.SetActive(true);

                    }
                }

                if (Page4 == true)
                {
                    if (other.gameObject.tag == "bookR2")
                    {
                        hit = false;
                        Obj.gameObject.SetActive(true);

                    }
                }
            }
        }
    }

    void Start()
    {

    }

    void Update()
    {
        // プレイヤーが地面にいるのか判定     falseなら地面にいる
        if (character.GetComponent<RayPlayer>().DownCheck == true)
        {
            if (hit == false)
            {
                var rb = Obj.GetComponent<Rigidbody>();
                float RstickX = Input.GetAxis("RstickX");

                // スティックを倒している間
                if (RstickX != 0)
                {
                    // Objに代入したオブジェクトを子オブジェクトにする
                    Obj.gameObject.transform.parent = this.gameObject.transform;
                }
                else
                {
                    // このオブジェクトを子オブジェクトから外す
                    Obj.gameObject.transform.parent = null;
                }
            }
        }
        else
        {
            // Objに代入したオブジェクトを子オブジェクトにする
            Obj.gameObject.transform.parent = this.gameObject.transform;
        }
    }
}



// オブジェクトの位置をobjと同じ位置にする
//  ReObj.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);


//ReObj.transform.parent = null;

//    rb.constraints = RigidbodyConstraints.FreezePositionZ
//                   | RigidbodyConstraints.FreezeRotationX
//                   | RigidbodyConstraints.FreezeRotationY;


//    rb.constraints = RigidbodyConstraints.FreezeAll;

