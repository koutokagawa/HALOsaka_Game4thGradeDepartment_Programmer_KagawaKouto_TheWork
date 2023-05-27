using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pagehit : MonoBehaviour
{
    private Rigidbody rb;
    private BoxCollider collider;

    //当たったかどうかの判定フラグ
    public bool ishitL;
    public bool ishitR;
   

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<BoxCollider>();

        //最初にfalseにする
        ishitL = false;
        ishitR = false;
    }

    void FixedUpdate()
    {
        float RstickX = Input.GetAxis("RstickX");

        if(RstickX != 0)
        {
            RigidONOFF();
        }
        else
        {
            rb.isKinematic = true;
        }

    }

    private void OnTriggerStay(Collider collision) //ほかのオブジェクトと接触したら呼び出される
    {
        if (collision.gameObject.name == "bookhitL")//接触したオブジェクトがbookhitLだったら処理を行う
        {
            ishitL = true;
        }

        if (collision.gameObject.name == "bookhitR")//接触したオブジェクトがbookhitRだったら処理を行う
        {
            ishitR = true;
        }
    }
    private void OnTriggerExit(Collider collision)//接触した後にはなれたら呼び出される
    {
        if (collision.gameObject.name == "bookhitL")//bookhitLから離れたら処理を行う
        {
            ishitL = false;
        }


        if (collision.gameObject.name == "bookhitR")//bookhitRから離れたら処理を行う
        {
            ishitR = false;
        }
    }

    private void RigidONOFF()
    {
        float RstickX = Input.GetAxis("RstickX");

        if (RstickX == 1.0f)
        {
           // rb.isKinematic = false;
        }
        else if (RstickX > 0.8f)
        {
           // rb.isKinematic = true;
        }
        else if (RstickX > 0.6f)
        {
         //   rb.isKinematic = true;
        }
        else if (RstickX > 0.4f)
        {
        //    rb.isKinematic = true;
        }
        else if (RstickX > 0.2f)
        {
        //    rb.isKinematic = true;
        }
        else if (RstickX > 0.0f)
        {
//rb.isKinematic = true;
        }

        // 左にステックを倒した場合

        if (RstickX == -1.0f)
        {
           // rb.isKinematic = false;
        }
        else if (RstickX < -0.8f)
        {
       //     rb.isKinematic = true;
        }
        else if (RstickX < -0.6f)
        {
        //    rb.isKinematic = true;
        }
        else if (RstickX < -0.4f)
        {
        //    rb.isKinematic = true;
        }
        else if (RstickX < -0.2f)
        {
        //    rb.isKinematic = true;
        }
        else if (RstickX < 0.0f)
        {
        //    rb.isKinematic = true;
        }
    }
}