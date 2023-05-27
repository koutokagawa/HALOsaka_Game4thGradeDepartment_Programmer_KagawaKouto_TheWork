using UnityEngine;

public class Candle : MonoBehaviour
{
    public float minEmissionIntensity = 0.0f; // 最小のエミッションの強さ
    public float maxEmissionIntensity = 50.0f; // 最大のエミッションの強さ
    public float period = 1.0f; // 光源が1サイクルにかかる時間

    private Material candleMaterial; // ろうそくのマテリアル

    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        candleMaterial = renderer.material;
    }

    private void Update()
    {
        // エミッションの強さを変更する
        float emissionIntensity = Mathf.Lerp(minEmissionIntensity, maxEmissionIntensity, Mathf.PingPong(Time.time / period, 1.0f));
        Color emissionColor = Color.white * Mathf.LinearToGammaSpace(emissionIntensity);
        candleMaterial.SetColor("_EmissionColor", emissionColor);
    }
}
