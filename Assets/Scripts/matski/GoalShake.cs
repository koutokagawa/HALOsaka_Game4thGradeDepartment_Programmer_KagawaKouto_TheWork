using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalShake : MonoBehaviour
{
    float time;
    float Farst;
    float y;
    Vector3 Sky;
    // Start is called before the first frame update
    void Start()
    {
        Farst = this.transform.position.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        y = Mathf.PerlinNoise(time, 0);
        if(y<0)
        {
            y = y * -1;
        }
        this.transform.position = new Vector3(this.transform.position.x, (y)+this.transform.parent.position.y, this.transform.position.z);
    }
}
