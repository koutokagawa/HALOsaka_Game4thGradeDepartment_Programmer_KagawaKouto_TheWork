using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MoveObj3 : MonoBehaviour
{
    Vector3 velocity;

    [Header("character�I�u�W�F�N�g������")] public GameObject character;

    private Rigidbody rb = null;

    [Header("Rigidbody�̃I���I�t�؂�ւ���L���ɂ���ꏊ")]
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
        // ���x��ۑ�
        //velocity = rb.velocity;

        float RstickX = Input.GetAxis("RstickX");

        // �R����I�u�W�F�N�g�ɓ������Ă��Ȃ��ꍇ
        if (flameHit == false)
        {
            // �v���C���[���n�ʂɂ���̂�����     false�Ȃ�n�ʂɂ���
            if (character.GetComponent<RayPlayer3>().DownCheck == true)
            {
                // �ړ��\�ȃI�u�W�F�N�g�ɓ������Ă���Ԃ͓�����
                if (moveLineHit == true)
                {
                    // moveObjHit�̃^�O���t�����I�u�W�F�N�g�ɓ������
                    // �y�[�W�ɌŒ肵�Ă����Ԃ��������ē����悤�ɂ���
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