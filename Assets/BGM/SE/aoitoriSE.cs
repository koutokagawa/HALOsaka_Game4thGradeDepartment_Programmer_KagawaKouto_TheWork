using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aoitoriSE : MonoBehaviour
{
    public AudioSource ad1;
    public AudioSource ad2;
    public AudioSource ad3;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bard_1")
        {
            ad1.Play();
        }

        if (collision.gameObject.tag == "Bard_2")
        {
            ad2.Play();
        }

        if (collision.gameObject.tag == "Bard_3")
        {
            ad3.Play();
        }
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
