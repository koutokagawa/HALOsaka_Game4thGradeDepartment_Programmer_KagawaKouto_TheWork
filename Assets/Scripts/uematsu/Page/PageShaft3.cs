using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class PageShaft3 : MonoBehaviour
{
    public bool isUp;
    #region//�C���X�y�N�^�[�Őݒ肷��
    [Header("page������")] public Pagehit hitcheck;
    [Header("headcheck������")] public PlayerUp upChrck;

    [Header("character�I�u�W�F�N�g������")] public GameObject character;
    #endregion

    float rotation = 0.0f;

    private bool tmp;

    private int cnt = 0;

    private bool checkA = false;
    private bool checkL = false;
    private bool checkR = false;

    void Start()
    {

    }

    void Update()
    {
        float Trigger = Input.GetAxis("LRtrigger");

        if (character.GetComponent<RayPlayer3>().DownCheck == true)
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
        // �v���C���[���n�ʂɂ���̂�����     false�Ȃ�n�ʂɂ���
        if (character.GetComponent<RayPlayer3>().DownCheck == false && upChrck.GetComponent<PlayerUp>().MaxUp == false)
        {
            RotationB();
        }

        // �v���C���[���ނ�グ���Ă���̂�    false�Ȃ�n�ʂɂ���
        else if (upChrck.GetComponent<PlayerUp>().MaxUp == true)
        {
            RotationA();
        }
        rotation = 0.0f;
    }

    // �������߂���
    public void RotationA()
    {
        // �E�X�e�B�b�N        
        float RstickX = Input.GetAxis("RstickX");

        // �E�X�e�B�b�N�̓|���p�x�Ńy�[�W�̉�]���x��ς���
        // �E�ɃX�e�b�N��|�����ꍇ
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


        // ���ɃX�e�b�N��|�����ꍇ
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

        // Y��(Vector3.up)������P�t���[�����̊p�x������]������Quaternion���쐬
        Quaternion rot = Quaternion.AngleAxis(rotation * Time.deltaTime, Vector3.forward);
        // ���̉�]�l�ƍ������ď㏑��
        transform.localRotation = rot * transform.localRotation;
    }

    // �f�����߂���
    public void RotationB()
    {
        // �E�X�e�B�b�N�̓|���p�x�Ńy�[�W�̉�]���x��ς���
        // �E�ɃX�e�b�N��|�����ꍇ
        if (hitcheck.GetComponent<Pagehit>().ishitL == false)
        {
            if (checkR == true)
            {
                rotation += 400.0f;
            }
        }
        else if (hitcheck.GetComponent<Pagehit>().ishitL == true)
        {
            rotation += 0.0f;
        }

        // ���ɃX�e�b�N��|�����ꍇ
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

        // Y��(Vector3.up)������P�t���[�����̊p�x������]������Quaternion���쐬
        Quaternion rot = Quaternion.AngleAxis(rotation * Time.deltaTime, Vector3.forward);

        // ���̉�]�l�ƍ������ď㏑��
        transform.localRotation = rot * transform.localRotation;
    }
}