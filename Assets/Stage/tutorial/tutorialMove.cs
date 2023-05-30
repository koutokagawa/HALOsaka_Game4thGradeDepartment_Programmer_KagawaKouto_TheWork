using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialMove : MonoBehaviour
{
    public GameObject screen1;
    public GameObject screen2;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            screen1.gameObject.SetActive(false);
            screen2.gameObject.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        screen1.gameObject.SetActive(true);
        screen2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
