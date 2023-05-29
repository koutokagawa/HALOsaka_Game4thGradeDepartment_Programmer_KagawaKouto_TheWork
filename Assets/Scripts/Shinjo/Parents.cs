using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parents : MonoBehaviour
{
    public GameObject[] children;

    void OnEnable()
    {
        if (children != null)
        {
            foreach (GameObject child in children)
            {
                if (child != null)
                {
                    child.transform.parent = this.transform;
                }
            }
        }

        this.enabled = false; // このスクリプトを無効化する
    }
}
