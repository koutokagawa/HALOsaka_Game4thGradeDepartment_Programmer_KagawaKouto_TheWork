using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gearrote_a_4 : MonoBehaviour
{
    private int cnt = 0;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (RayPlayer4.instance.UpCount == false)
        {
            if (RayPlayer4.instance.DownCheck == true)
            {
                cnt = 1;
            }
            else
            {
                cnt = 0;
            }
        }
        

        if (cnt == 1)
        {
            transform.Rotate(new Vector3(0, 0, -1));
        }
     

    }
}
