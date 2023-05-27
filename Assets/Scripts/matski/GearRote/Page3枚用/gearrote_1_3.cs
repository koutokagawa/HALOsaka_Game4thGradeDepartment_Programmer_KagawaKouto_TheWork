using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gearrote_1_3 : MonoBehaviour
{
    private int cnt = 0;
    public PlayerUp headcheck;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (RayPlayer3.instance.NowMoveflg == true)
        {
            cnt = 1;
        }
        else
        {
            cnt = 0;
        }

        if (RayPlayer3.instance.UpCount == true)
        {
            cnt = 1;
        }
        if(RayPlayer3.instance.gearStop==true)
        {
            cnt = 0;
        }

        if (cnt == 1)
        {
            transform.Rotate(new Vector3(0, 0, 1));
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, 0));
        }

    }
}
