using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RplayObject : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    [Tooltip("����������Object��ݒ�")]
    private GameObject Prefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject playerObj = GameObject.Find(Prefab.name);
        // playerObj�����݂��Ă��Ȃ��ꍇ
        if (playerObj == null)
        {
            // playerPrefab����V����GameObject���쐬
            GameObject newPlayerObj = Instantiate(Prefab);

            // �V�����쐬����GameObject�̖��O���Đݒ�(�����"PlayerSphere"�ƂȂ�)
            newPlayerObj.name = Prefab.name;
            // �������Ŗ��O���Đݒ肵�Ȃ��ꍇ�A�����Ō��܂閼�O�́A"PlayerSphere(Clone)"�ƂȂ邽��
            //   13�s�ڂŒT���Ă���"PlayerSphere"���i���Ɍ�����Ȃ����ƂɂȂ�Aplayer�������ɐ��Y�����

        }
        }
    }
