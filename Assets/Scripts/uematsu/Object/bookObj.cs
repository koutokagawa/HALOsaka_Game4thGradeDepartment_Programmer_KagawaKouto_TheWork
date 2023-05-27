using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bookObj : MonoBehaviour
{
    public GameObject bookPosObj;

    private bool hit = false;

    public bool ObjectPosL = false;
    public bool ObjectPosR = false;

    void OnTriggerStay(Collider other)
    {
        if (ObjectPosL == true)
        {
            if (other.gameObject.tag == "pagehit2_page1")
            {
                hit = true;
            }
        }

        if (ObjectPosR == true)
        {
            if (other.gameObject.tag == "pagehit2_page1" || other.gameObject.tag == "pagehit2_page2" || other.gameObject.tag == "pagehit2_page3")
            {
                hit = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (ObjectPosL == true)
        {
            if (other.gameObject.tag == "pagehit2_page1")
            {
                hit = false;
            }
        }

        if (ObjectPosR == true)
        {
            if (other.gameObject.tag == "pagehit2_page1" || other.gameObject.tag == "pagehit2_page2" || other.gameObject.tag == "pagehit2_page3")
            {
                hit = false;
            }
        }
    }

    void Start()
    {
        bookPosObj.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (hit == true)
        {
            bookPosObj.gameObject.SetActive(false);
        }

        if (hit == false)
        {
            bookPosObj.gameObject.SetActive(true);
        }
    }
}
