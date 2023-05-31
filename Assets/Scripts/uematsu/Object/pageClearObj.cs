using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pageClearObj : MonoBehaviour
{
    [Header("復活させるオブジェクト")]
    public GameObject Obj;
   

    [Header("ページが縦向きの状態だとしてのオブジェクトの位置")]
    public bool ObjectPosL = false;
    public bool ObjectPosR = false;

    [Header("このオブジェクトがあるページを選択する")]
    public bool Page1 = false;
    public bool Page2 = false;
    public bool Page3 = false;

    private bool hit = false;

    void OnTriggerStay(Collider other)
    {
        // オブジェクトが本の左側にある場合
        if (ObjectPosL == true)
        {
            if (Page1 == true)
            {
                if (other.gameObject.tag == "bookL2")
                {
                    hit = true;
                }
            }

            if (Page2 == true)
            {
                if (other.gameObject.tag == "pagehit2_page1")
                {
                    hit = true;
                }
            }

            if (Page3 == true)
            {
                if (other.gameObject.tag == "pagehit2_page2")
                {
                    hit = true;
                }
            }
        }

        // オブジェクトが本の右側にある場合
        if (ObjectPosR == true)
        {
            if (Page1 == true)
            {
                if (other.gameObject.tag == "pagehit2_page2")
                {
                    hit = true;
                }
            }

            if (Page2 == true)
            {
                if (other.gameObject.tag == "pagehit2_page3" || other.gameObject.tag == "bookR2")
                {
                    hit = true;
                }
            }

            if (Page3 == true)
            {
                if (other.gameObject.tag == "bookR2")
                {
                    hit = true;
                }
            }
        }

        //if (other.gameObject.tag == "bookUnderHit")
        //{
        //    Obj.gameObject.SetActive(false);
           
        //}

        if(other.gameObject.tag == "moveobj"/*||other.gameObject.tag=="lockobj"*/)
        {
            hit = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // オブジェクトが本の左側にある場合
        if (ObjectPosL == true)
        {
            if (Page1 == true)
            {
                if (other.gameObject.tag == "bookL2")
                {
                    hit = false;
                }

                if (other.gameObject.tag == "pagehit2_page2")
                {
                    hit = false;
                }
            }

            if (Page2 == true)
            {
                if (other.gameObject.tag == "pagehit2_page1")
                {
                    hit = false;
                }
            }

            if (Page3 == true)
            {
                if (other.gameObject.tag == "pagehit2_page2")
                {
                    hit = false;
                }
            }
        }

        // オブジェクトが本の右側にある場合
        if (ObjectPosR == true)
        {
            if (Page1 == true)
            {
                if (other.gameObject.tag == "pagehit2_page2")
                {
                    hit = false;
                }
            }

            if (Page2 == true)
            {
                if (other.gameObject.tag == "pagehit2_page3" || other.gameObject.tag == "bookR2")
                {
                    hit = false;
                }
            }

            if (Page3 == true)
            {
                if (other.gameObject.tag == "bookR2")
                {
                    hit = false;
                }

                if (other.gameObject.tag == "pagehit2_page2")
                {
                    hit = false;
                }
            }
        }

        //if (other.gameObject.tag == "bookUnderHit")
        //{
        //    Obj.gameObject.SetActive(true);
        //}

        if (other.gameObject.tag == "moveobj" || other.gameObject.tag == "flame")
        {
            hit = false;
        }
    }


    void Start()
    {
        Obj.gameObject.SetActive(false);
       
    }

    void FixedUpdate()
    {
        if (hit == true)
        {
            Obj.gameObject.SetActive(false); 
        }

        if (hit == false)
        {
            Obj.gameObject.SetActive(true);
        }
    }
}
