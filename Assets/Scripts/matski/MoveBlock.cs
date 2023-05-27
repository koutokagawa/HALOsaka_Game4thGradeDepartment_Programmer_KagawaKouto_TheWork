using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    int counter = 0;
    float move = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, move));
        counter++;
        if(counter==300)
        {
            counter = 0;
            move *= -1;
        }
    }
}
