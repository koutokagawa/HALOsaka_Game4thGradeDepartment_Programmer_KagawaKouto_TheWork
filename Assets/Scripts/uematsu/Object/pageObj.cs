using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pageObj : MonoBehaviour
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
    public bool Page4 = false;

    private bool hit = false;
    public bool flameHit = false;


    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "flame")
        {
            flameHit = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "flame")
        {
            flameHit = true;
        }

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
                if (other.gameObject.tag == "pagehit2_page1" || other.gameObject.tag == "bookL2")
                {
                    hit = true;
                }
            }

            if (Page3 == true)
            {
                if (other.gameObject.tag == "pagehit2_page2" || other.gameObject.tag == "bookL2")
                {
                    hit = true;
                }
            }

            if (Page4 == true)
            {
                if (other.gameObject.tag == "pagehit2_page3" || other.gameObject.tag == "bookL2")
                {
                    hit = true;
                }
            }
        }

        if (ObjectPosR == true)
        {
            if (Page1 == true)
            {
                if (other.gameObject.tag == "pagehit2_page2" || other.gameObject.tag == "bookR2")
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
                if (other.gameObject.tag == "pagehit2_page4" || other.gameObject.tag == "bookR2")
                {
                    hit = true;
                }
            }

            if (Page4 == true)
            {
                if (other.gameObject.tag == "bookR2")
                {
                    hit = true;
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "flame")
        {
            flameHit = false;
        }

        if (ObjectPosL == true)
        {
            if (Page1 == true)
            {
                if (other.gameObject.tag == "bookL2")
                {
                    hit = false;
                }
            }

            if (Page2 == true)
            {
                if (other.gameObject.tag == "pagehit2_page1" || other.gameObject.tag == "bookL2")
                {
                    hit = false;
                }
            }

            if (Page3 == true)
            {
                if (other.gameObject.tag == "pagehit2_page2" || other.gameObject.tag == "bookL2")
                {
                    hit = false;
                }
            }

            if (Page4 == true)
            {
                if (other.gameObject.tag == "pagehit2_page3" || other.gameObject.tag == "bookL2")
                {
                    hit = false;
                }
            }
        }

        if (ObjectPosR == true)
        {
            if (Page1 == true)
            {
                if (other.gameObject.tag == "pagehit2_page2" || other.gameObject.tag == "bookR2")
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
                if (other.gameObject.tag == "pagehit2_page4" || other.gameObject.tag == "bookR2")
                {
                    hit = false;
                }
            }

            if (Page4 == true)
            {
                if (other.gameObject.tag == "bookR2")
                {
                    hit = false;
                }
            }
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        if (hit == false)
        {
            Obj.gameObject.SetActive(true);
        }

        if (flameHit == true)
        {
            Obj.gameObject.SetActive(false);
        }

        if (hit == true)
        {
            Obj.gameObject.SetActive(false);
        }
    }

}
