using UnityEngine;

public class CandleEffect : MonoBehaviour
{
    private Light candleLight;
    private GameObject candle;

    private void Start()
    {
        candleLight = gameObject.AddComponent<Light>();
        candleLight.color = Color.yellow;
        candleLight.range = 50.0f;
        candleLight.intensity = 5.0f;
        candleLight.type = LightType.Point;

        candle = GameObject.Find("Candle");
        candleLight.transform.position = candle.transform.position;

        Material candleMaterial = candle.GetComponent<Renderer>().material;
        candleMaterial.EnableKeyword("_EMISSION");
        candleMaterial.SetColor("_EmissionColor", Color.yellow);
    }

    private void Update()
    {
        //float x = Random.Range(-0.1f, 0.1f);
        //float y = Random.Range(-0.1f, 0.1f);
        //float z = Random.Range(-0.1f, 0.1f);
        //candleLight.transform.position += new Vector3(x, y, z);
    }
}
