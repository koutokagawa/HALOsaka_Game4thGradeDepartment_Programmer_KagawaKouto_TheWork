using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBard : MonoBehaviour
{

    float fadeSpeed = 0.01f;        // �����x���ς��X�s�[�h
    float red, green, blue, alfa;   // Material�̐F

    public bool isFadeOut = false;  // �t�F�[�h�A�E�g�����̊J�n�A�������Ǘ�
    public bool isFadeIn = false;   // �t�F�[�h�C�������̊J�n�A�������Ǘ�

    private int a = 0;

    [SerializeField] private bool Birdflg;

    Renderer fadeMaterial;          // Material�ɃA�N�Z�X����e��
    // Start is called before the first frame update
    void Start()
    {
        fadeMaterial = GetComponent<Renderer>();
        red = fadeMaterial.material.color.r;
        green = fadeMaterial.material.color.g;
        blue = fadeMaterial.material.color.b;
        alfa = fadeMaterial.material.color.a;
        isFadeIn = true;
        Birdflg = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFadeIn)
        {
            StartFadeIn(); // bool�Ƀ`�F�b�N�������Ă�������s
        }
        if (isFadeOut)
        {
            StartFadeOut(); //bool�Ƀ`�F�b�N�������Ă�������s     
        }

        if(Birdflg==true)
        {
         

            if ((alfa <= 0))
            {

                if (this.CompareTag("Bard_1"))
                {
                    this.transform.position = new Vector3(-7.8f, 19.3f, -15.5f);
                }
                else if (this.CompareTag("Bard_2"))
                {
                    this.transform.position = new Vector3(-5.8f, 19.3f, -15.5f);
                }
                else if (this.CompareTag("Bard_3"))
                {
                    this.transform.position = new Vector3(-3.8f, 19.3f, -15.5f);
                }
                isFadeIn = true;
            }
          
            
        }
    }

    void StartFadeOut()
    {
        alfa -= fadeSpeed;         // �s�����x��������
        SetAlpha();               // �ύX���������x�𔽉f����
        if (alfa <= 0)              // ���S�ɓ����ɂȂ����珈���𔲂���
        {
            isFadeOut = false;     // bool�̃`�F�b�N���O���
            fadeMaterial.enabled = false;  // Material�̕`����I�t�ɂ���
        }
    }
    void StartFadeIn()
    {
        fadeMaterial.enabled = true;  // Material�̕`����I���ɂ���
        alfa += fadeSpeed;          // �s�����x�����X�ɏグ��
        SetAlpha();                // �ύX�����s�����x�𔽉f����
        if (alfa >= 1)               // ���S�ɕs�����ɂȂ����珈���𔲂���
        {
            isFadeIn = false;       // bool�̃`�F�b�N���O���
        }
    }
    void SetAlpha()
    {
        fadeMaterial.material.color = new Color(red, green, blue, alfa);
        // �ύX�����s�����x���܂�Material�̃J���[�𔽉f����
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Birdflg = true;
            isFadeOut = true;
        }
    }
}
