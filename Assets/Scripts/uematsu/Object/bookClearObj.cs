using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookClearObj : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
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
