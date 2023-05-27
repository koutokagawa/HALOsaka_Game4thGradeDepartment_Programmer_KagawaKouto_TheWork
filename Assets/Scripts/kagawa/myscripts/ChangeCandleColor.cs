using UnityEngine;

public class ChangeCandleColor : MonoBehaviour
{
    public Material candleMaterial;

    void Start()
    {
        candleMaterial.color = new Color(1.0f, 0.65f, 0.0f);
    }
}
