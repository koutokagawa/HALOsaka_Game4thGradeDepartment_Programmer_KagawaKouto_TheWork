using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpTargetMove : MonoBehaviour
{


    private Vector3 targetVector;
    private GameObject pagemove;//pagemoveÇéQè∆Ç∑ÇÈÇΩÇﬂÇÃïœêî
    private GameObject character;

    [SerializeField] Transform target;
    // Start is called before the first frame update
    void Start()
    {
        pagemove = GameObject.Find("ShaftManager");
        character = GameObject.Find("headcheck");
    }

    // Update is called once per frame
    void Update()
    {
        targetVector = new Vector3(target.position.x, this.transform.position.y, target.position.z);
        this.transform.position = Vector3.MoveTowards(this.transform.position, targetVector, 8.0f * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        if (pagemove.GetComponent<ShaftManager1>().pageMove1 == true )
        {
            this.GetComponent<BoxCollider>().isTrigger = true;
        }
       else if (pagemove.GetComponent<ShaftManager1>().pageMove1 == false)
        {
            this.GetComponent<BoxCollider>().isTrigger = false;
        }



        if(character.GetComponent<PlayerUp>().MaxUp == true)
        {
            this.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}