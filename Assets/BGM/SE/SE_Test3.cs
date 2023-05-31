using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_Test3 : MonoBehaviour
{
    public AudioSource ad;
    public RayPlayer2 RP2;

    // Start is called before the first frame update
    void Start()
    {
        ad.Stop();
    }

    // Update is called once per frame
    void Update()
    {

        //float LstickX = Input.GetAxis("LstickX");
        //float LstickY = Input.GetAxis("LstickY");

        //if (!(-0.01f <= LstickX && LstickX <= 0.01f) || !(-0.01f <= LstickY && LstickY <= 0.01f))
        if (RP2.NowMoveflg)
        {

            if (RP2.DownCheck != true)
            {
                if (ad.isPlaying == false)
                {
                    ad.Play();
                }
            }
        }
        else
        {
            ad.Stop();
        }
    }
}

