using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear_SE : MonoBehaviour
{
    public AudioSource ad;

    public RayPlayer rp;
    public PlayerUp pu;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (rp.DownCheck == true)
        {
            if (pu.MaxUp == false)
            {
                ad.Play();
            }
        }
    }
}