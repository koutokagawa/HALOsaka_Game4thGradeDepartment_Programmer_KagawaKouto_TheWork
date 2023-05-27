using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MHitCheck : MonoBehaviour
{
    //void OnCollisionEnter(Collision collision)
    //{
    //    UnityEngine.Debug.Log("hit");
    //}
    public GameObject hitpage;//他オブジェクト参照用

    void OnCollisionStay(Collision collision)
    {
      
        //if (collision.gameObject.name =="book_a")//当たったオブジェクトがbook_aなら処理する
        //{
        //    UnityEngine.Debug.Log("当たっている");
        //   //if(hitpage.GetComponent<MObjectMove>().isCubeHit==true)//MObjectMoveスクリプトのisCubeHitを参照する
        //   // {
        //   //     Destroy(gameObject);//このスクリプトが入ったオブジェクトを消す
        //   // }
        //}
    }

    //void OnTriggerExit(Collider other)
    //{
    //    UnityEngine.Debug.Log("通り抜け終えた");
    //}

    // Start is called before the first frame update
    void Start()
    {
        hitpage = GameObject.Find("page");//参照するオブジェクトを指定する
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
