using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gearrote_b_2 : MonoBehaviour
{
    private int cnt = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (RayPlayer2.instance.UpCount == false)
        {
            if (RayPlayer2.instance.DownCheck == true)
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
            transform.Rotate(new Vector3(0, -1, 0));
        }
    

    }
}
