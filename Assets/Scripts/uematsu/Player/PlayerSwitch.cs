using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "RayHitObjTopUnder")
        {
           

            if (GetComponent<Collider>().gameObject.activeSelf)
            {
                UnityEngine.Debug.Log(other);
                this.gameObject.SetActive(true);
            }
            else
            {
                UnityEngine.Debug.Log(other);
                this.gameObject.SetActive(false);
            }


            //if (other.activeSelf)
            //{

            //}
        }

        //    UnityEngine.Debug.Log("activeSelf: " + other.activeSelf);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
