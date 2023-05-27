using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReSpawnObjectVer2 : MonoBehaviour
{
    // ���X�|�[��������I�u�W�F�N�g������
    [Header("�����ʒu�ɂȂ�I�u�W�F�N�g")]
    public GameObject posObj;

    [Header("����������I�u�W�F�N�g")]
    public GameObject obj;

    [Header("�e�ɂȂ�I�u�W�F�N�g")]
    public GameObject parentObj;

    [Header("�y�[�W���J�������̃I�u�W�F�N�g�̈ʒu")]
    public bool ObjectPosL = false;
    public bool ObjectPosR = false;

    private bool bookHit = true;

   
    void OnTriggerEnter(Collider other)
    {


    }

    void OnTriggerExit(Collider other)
    {
        if (ObjectPosL == false)
        {
            if (other.gameObject.tag == "bookR")
            {
                bookHit = false;
            }
        }

        if (ObjectPosR == false)
        {
            if (other.gameObject.tag == "bookL")
            {
                bookHit = false;
            }
        }


    }

    void Start()
    {
        // �V�����쐬�����I�u�W�F�N�g�̈ʒu��obj�Ɠ����ʒu�ɂ���
        obj.transform.position = new Vector3(posObj.transform.position.x, posObj.transform.position.y, posObj.transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        // ����������I�u�W�F�N�g�����݂��Ȃ��ꍇ
        if (obj.activeInHierarchy == false)
        {
            // �{���痣�ꂽ�ꍇ
            if (bookHit == false)
            {
                // �I�u�W�F�N�g�𕜊�������
                obj.gameObject.SetActive(true);

                // �V�����쐬�����I�u�W�F�N�g�̈ʒu��obj�Ɠ����ʒu�ɂ���
                obj.transform.position = new Vector3(posObj.transform.position.x, posObj.transform.position.y, posObj.transform.position.z);

                //parentObj�̎q�I�u�W�F�N�g�ɐݒ肷��
                obj.transform.parent = parentObj.transform;

                // ��x�������s���邽�߂�false�ɂ���
                bookHit = false;


            }
        }
    }
}
