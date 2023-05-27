using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpTargetline : MonoBehaviour
{


    private Vector3 targetVector;
    [SerializeField] Transform target;
    int a = 0;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float LstickX = Input.GetAxis("LstickX");

        if (LstickX < 0)
        {
            a = 1;
           
        }
        else if(LstickX>0)
        {
            a = 0;
           
        }
        
        if (a == 0)
        {
            targetVector = new Vector3(target.position.x - 0.7f, target.position.y + 10.0f, target.position.z + 0.2f);
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetVector, 20.0f * Time.deltaTime);
        }
        else if(a==1)
        {
            targetVector = new Vector3(target.position.x + 0.7f, target.position.y + 10.0f, target.position.z + 0.2f);
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetVector, 20.0f * Time.deltaTime);
        }

    }
}