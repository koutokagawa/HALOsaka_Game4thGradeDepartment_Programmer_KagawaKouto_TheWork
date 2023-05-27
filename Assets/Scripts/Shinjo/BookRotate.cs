using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookRotate : MonoBehaviour
{
    public float rotationSpeed = 10.0f;
    private float rotationAngle = 0.0f;

    void Update()
    {
        float rotationStep = rotationSpeed * Time.deltaTime;
        if (rotationAngle + rotationStep > 180.0f)
        {
            rotationStep = 180.0f - rotationAngle;
        }

        transform.Rotate(Vector3.up, rotationStep);
        rotationAngle += rotationStep;

        if (rotationAngle >= 180.0f)
        {
            enabled = false;
        }
    }
}
