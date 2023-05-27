using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUp : MonoBehaviour
{
    public bool MaxUp;

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.name == "playerUpTarget")
        {
            MaxUp = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "playerUpTarget")
        {
            MaxUp = false;
        }
    }
}
