using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rigidonoff : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {

    }

    void Update()
    {
        // Rigidbody���擾
        rb = GetComponent<Rigidbody>();
        //   E�L�[�����������iSphere�𔭎ˁj
        if (Input.GetKeyDown(KeyCode.E))
        {
            UnityEngine.Debug.Log("�؂�ւ���");
            rb.isKinematic = true;
        }
        //rb.isKinematic = false;
    }
}
