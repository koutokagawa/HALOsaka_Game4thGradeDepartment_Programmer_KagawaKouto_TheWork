using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBard : MonoBehaviour
{

    float fadeSpeed = 0.01f;        // 透明度が変わるスピード
    float red, green, blue, alfa;   // Materialの色

    public bool isFadeOut = false;  // フェードアウト処理の開始、完了を管理
    public bool isFadeIn = false;   // フェードイン処理の開始、完了を管理

    Renderer fadeMaterial;          // Materialにアクセスする容器
    // Start is called before the first frame update
    void Start()
    {
        fadeMaterial = GetComponent<Renderer>();
        red = fadeMaterial.material.color.r;
        green = fadeMaterial.material.color.g;
        blue = fadeMaterial.material.color.b;
        alfa = fadeMaterial.material.color.a;
        isFadeIn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFadeIn)
        {
            StartFadeIn(); // boolにチェックが入っていたら実行
        }
        if (isFadeOut)
        {
            StartFadeOut(); //boolにチェックが入っていたら実行     
        }
    }

    void StartFadeOut()
    {
        alfa -= fadeSpeed;         // 不透明度を下げる
        SetAlpha();               // 変更した透明度を反映する
        if (alfa <= 0)              // 完全に透明になったら処理を抜ける
        {
            isFadeOut = false;     // boolのチェックが外れる
            fadeMaterial.enabled = false;  // Materialの描画をオフにする
        }
    }
    void StartFadeIn()
    {
        fadeMaterial.enabled = true;  // Materialの描画をオンにする
        alfa += fadeSpeed;          // 不透明度を徐々に上げる
        SetAlpha();                // 変更した不透明度を反映する
        if (alfa >= 1)               // 完全に不透明になったら処理を抜ける
        {
            isFadeIn = false;       // boolのチェックが外れる
        }
    }
    void SetAlpha()
    {
        fadeMaterial.material.color = new Color(red, green, blue, alfa);
        // 変更した不透明度を含むMaterialのカラーを反映する
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "characterHit")
        {
            if (this.CompareTag("Bard_1"))
            {
                this.transform.position = new Vector3(-13.0f, 17.3f, -12.5f);
            }
            else if (this.CompareTag("Bard_2"))
            {
                this.transform.position = new Vector3(-11.0f, 17.3f, -12.5f);
            }
            else if (this.CompareTag("Bard_3"))
            {
                this.transform.position = new Vector3(-9.0f, 17.3f, -12.5f);
            }
        }
    }
}
