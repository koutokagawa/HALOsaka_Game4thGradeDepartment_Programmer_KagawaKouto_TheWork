using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCover : MonoBehaviour
{
    public float rotationSpeed = 10.0f;
    public float rotationrimit = 90.0f;
    private float rotationAngle = 0.0f;

    void Update()
    {
        float rotationStep = rotationSpeed * Time.deltaTime;
        if (rotationAngle + rotationStep > rotationrimit)
        {
            rotationStep = rotationrimit - rotationAngle;
        }

        transform.Rotate(Vector3.up, rotationStep);
        rotationAngle += rotationStep;

        if (rotationAngle >= rotationrimit)
        {
            enabled = false;
        }
    }
}
