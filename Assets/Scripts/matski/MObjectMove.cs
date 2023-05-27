using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MObjectMove : MonoBehaviour
{
    private Rigidbody rb;
    private BoxCollider collider;
    public PhysicMaterial Slip;
    public PhysicMaterial nonSlip;

    //当たったかどうかの判定フラグ
    public bool ishitL;
    public bool ishitR;
    public bool isCubeHit;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<BoxCollider>();
        
        //最初にfalseにする
        ishitL = false;
        ishitR = false;
        isCubeHit = false;
    }

    void Update()
    {


        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) { collider.material = Slip; }
        else
        {
            collider.material = nonSlip;
        }
        if(isCubeHit==true)
        {
            isCubeHit = false;
        }
        //if (Input.GetKey(KeyCode.RightArrow)) { collider.material = Slip; }
        //else
        //{
        //    collider.material = nonSlip;
        //}

        //if (Input.GetMouseButtonDown(0))
        //{
        //    time = 1;
        //    rb.AddForce(force, 0, 0, ForceMode.Impulse);
        //}

    }
    private void OnCollisionStay(Collision collision) //ほかのオブジェクトと接触したら呼び出される
    {

        if (collision.gameObject.name == "bookhitL")//接触したオブジェクトがbookhitLだったら処理を行う
        {
            ishitL = true;
            //Debug.Log("左");
        }


        if (collision.gameObject.name == "bookhitR")//接触したオブジェクトがbookhitRだったら処理を行う
        {
            ishitR = true;
            //Debug.Log("右");
        }

        if (collision.gameObject.name=="Cube")//接触したオブジェクトがCubeだったらだったら処理を行う
        {

            isCubeHit = true;
        }
    }
    private void OnCollisionExit(Collision collision)//接触した後にはなれたら呼び出される
    {
        if (collision.gameObject.name == "bookhitL")//bookhitLから離れたら処理を行う
        {
            ishitL = false;
            //Debug.Log("左離れた");
        }


        if (collision.gameObject.name == "bookhitR")//bookhitRから離れたら処理を行う
        {
            ishitR = false;
            //Debug.Log("右離れた");
        }
        if (collision.gameObject.name == "Cube")//cubeから離れたら処理を行う
        {
            isCubeHit = false;
        }

    }
}