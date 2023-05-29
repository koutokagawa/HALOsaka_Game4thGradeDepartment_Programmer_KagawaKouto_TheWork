using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parentalseparation : MonoBehaviour
{

    public GameObject[] parents;

    // Start is called before the first frame update
    void OnEnable()
    {
        if (parents != null)
        {
            foreach (GameObject parent in parents)
            {
                if (parent != null)
                {
                    parent.transform.parent = this.transform;
                }
            }
        }
        this.enabled = false; // このスクリプトを無効化する
    }
}
