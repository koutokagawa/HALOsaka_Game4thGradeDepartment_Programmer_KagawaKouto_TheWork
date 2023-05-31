using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class MoveObjManager2 : MonoBehaviour
{
    [Header("character�I�u�W�F�N�g������")] public GameObject character;

    [Header("����������I�u�W�F�N�g")]
    public GameObject Obj;
    public MoveObj2 script;

    [Header("�y�[�W���c�����̏�Ԃ��Ƃ��ẴI�u�W�F�N�g�̈ʒu")]
    public bool ObjectPosL = false;
    public bool ObjectPosR = false;

    [Header("���̃I�u�W�F�N�g������y�[�W��I������")]
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

    // Update is called once per frame
    void Update()
    {
        if (Obj != null)
        {
            // �v���C���[���n�ʂɂ���̂�����     false�Ȃ�n�ʂɂ���
            if (character.GetComponent<RayPlayer2>().DownCheck == true)
            {
                if (hit == false)
                {
                    // ���ɓ������������
                    //if (script.flameHit == true)
                    //{
                    //    ReObj.gameObject.SetActive(false);
                    //}
                    //else
                    //{
                    //    ReObj.gameObject.SetActive(true);
                    //}

                    var rb = Obj.GetComponent<Rigidbody>();
                    float RstickX = Input.GetAxis("RstickX");

                    // �X�e�B�b�N��|���Ă����
                    if (RstickX != 0)
                    {
                        // Obj�ɑ�������I�u�W�F�N�g���q�I�u�W�F�N�g�ɂ���
                        Obj.gameObject.transform.parent = this.gameObject.transform;
                    }
                    else
                    {
                        // ���̃I�u�W�F�N�g���q�I�u�W�F�N�g����O��
                        Obj.gameObject.transform.parent = null;
                    }
                }
                else
                {
                   // Obj.gameObject.SetActive(false);
                }
            }
            else
            {
                if (Obj != null)
                {
                    // Obj�ɑ�������I�u�W�F�N�g���q�I�u�W�F�N�g�ɂ���
                    Obj.gameObject.transform.parent = this.gameObject.transform;
                }
            }
        }

          
    }
}



// �I�u�W�F�N�g�̈ʒu��obj�Ɠ����ʒu�ɂ���
//  ReObj.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);


//ReObj.transform.parent = null;

//    rb.constraints = RigidbodyConstraints.FreezePositionZ
//                   | RigidbodyConstraints.FreezeRotationX
//                   | RigidbodyConstraints.FreezeRotationY;


//    rb.constraints = RigidbodyConstraints.FreezeAll;

