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
        // Rigidbodyを取得
        rb = GetComponent<Rigidbody>();
        //   Eキーを押した時（Sphereを発射）
        if (Input.GetKeyDown(KeyCode.E))
        {
            UnityEngine.Debug.Log("切り替えた");
            rb.isKinematic = true;
        }
        //rb.isKinematic = false;
    }
}
