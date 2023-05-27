using UnityEngine;

public class Candle : MonoBehaviour
{
    public float minEmissionIntensity = 0.0f; // �ŏ��̃G�~�b�V�����̋���
    public float maxEmissionIntensity = 50.0f; // �ő�̃G�~�b�V�����̋���
    public float period = 1.0f; // ������1�T�C�N���ɂ����鎞��

    private Material candleMaterial; // �낤�����̃}�e���A��

    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        candleMaterial = renderer.material;
    }

    private void Update()
    {
        // �G�~�b�V�����̋�����ύX����
        float emissionIntensity = Mathf.Lerp(minEmissionIntensity, maxEmissionIntensity, Mathf.PingPong(Time.time / period, 1.0f));
        Color emissionColor = Color.white * Mathf.LinearToGammaSpace(emissionIntensity);
        candleMaterial.SetColor("_EmissionColor", emissionColor);
    }
}
