using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "characterHit")
        {
            if (this.CompareTag("Bard_1"))
            {
                this.transform.position = new Vector3(-13.0f, 17.3f, -12.5f);
            }
            else if (this.CompareTag("Bard_2"))
            {
                this.transform.position = new Vector3(-11.0f, 17.3f, -12.5f);
            }
            else if (this.CompareTag("Bard_3"))
            {
                this.transform.position = new Vector3(-9.0f, 17.3f, -12.5f);
            }
        }
    }
}
