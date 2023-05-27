using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class MPageShaft : MonoBehaviour
{

    public bool isUp;//�y�[�W�𓮂����Ă��邩�ǂ����̔���t���O
    public GameObject hitcheck;//���I�u�W�F�N�g���Q�Ƃ���

    void Start()
    {
        isUp = false;//�ŏ��͓����ĂȂ��̂�false������
        hitcheck = GameObject.Find("page");//�Q�Ƃ���I�u�W�F�N�g���w�肷��
    }

    void Update()
    {
        Rotation();
        
    }



    public void Rotation()
    {
        // ���E�L�[���͂ɉ����ĉ�]���x������
        float speed = 0.0f;

        //bookhitL��true(�y�[�W�̒[�ɓ������Ă���)�Ƃ���false(�����Ă��Ȃ�)���ł��ꂼ��ʂ̔�����s��
        if (hitcheck.GetComponent<MObjectMove>().ishitL == false)//MObject Script��ishitL���Q�Ƃ���
        {

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                speed += 45.0f;
                isUp = true;//�y�[�W�������Ă���̂�true�ɂ���
            }
            else
            {
                isUp = false;//�y�[�W�������ĂȂ��̂�false�ɂ���
            }
        }
        else if (hitcheck.GetComponent<MObjectMove>().ishitL == true)//MObject��ishitL���Q�Ƃ���
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                speed += 0.0f;
                isUp = false;//�y�[�W�������ĂȂ��̂�false
            }
        }

        //bookhitR��true(�y�[�W�̒[�ɓ������Ă���)�Ƃ���false(�����Ă��Ȃ�)���ł��ꂼ��ʂ̔�����s��
        if (hitcheck.GetComponent<MObjectMove>().ishitR == false)//MObject Script��ishitR���Q�Ƃ���
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                speed += -45.0f;
                isUp = true;//�y�[�W�������Ă���̂�true�ɂ���
            }
            else
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    isUp = true;//�y�[�W�������Ă���̂�true�ɂ���
                }
                else
                {
                    isUp = false;//�y�[�W�������ĂȂ��̂�false
                }
                   
            }
        }
        else if (hitcheck.GetComponent<MObjectMove>().ishitR == true)//MObject Script��ishitR���Q�Ƃ���
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                speed += 0.0f;
                isUp = false;//�y�[�W�������ĂȂ��̂�false
            }
        }

            // Y��(Vector3.up)������P�t���[�����̊p�x������]������Quaternion���쐬
            Quaternion rot = Quaternion.AngleAxis(speed * Time.deltaTime, Vector3.forward);

        // ���̉�]�l�ƍ������ď㏑��
        transform.localRotation = rot * transform.localRotation;
    }

}

