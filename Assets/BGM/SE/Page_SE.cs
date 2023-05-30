using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page_SE : MonoBehaviour
{

    public AudioSource ad;

    // Start is called before the first frame update
    void Start()
    {
        ad.Stop();
    }

    // Update is called once per frame
    void Update()
    {

        float RstickX = Input.GetAxis("RstickX");
        //float LstickY = Input.GetAxis("LstickY");

        if (!(-0.01f <= RstickX && RstickX <= 0.01f))
        {
            if (ad.isPlaying == false)
            {
                ad.Play();
            }
        }
        else
        {
            ad.Stop();
        }
    }
}
