using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalShake : MonoBehaviour
{
    float time;
    float y;
    Vector3 Sky;
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        y = Mathf.PerlinNoise(time, 0);
        this.transform.position = new Vector3(this.transform.position.x, (y*1.5f)+3.2f, this.transform.position.z);
    }
}
