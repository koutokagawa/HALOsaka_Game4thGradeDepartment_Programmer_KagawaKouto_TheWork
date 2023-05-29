using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame1 : MonoBehaviour
{
    public GameObject Obj;
    public GameObject flame; // �Ǐ]��I�u�W�F�N�g��Transform

    public float count = 0;

    // Start is called before the first frame update
    void Start()
    {
        flame.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Obj != null)
        {
            // �I�u�W�F�N�g�̈ʒu��obj�Ɠ����ʒu�ɂ���
            flame.transform.position = new Vector3(Obj.transform.position.x, Obj.transform.position.y, Obj.transform.position.z);

            if (Obj.GetComponent<MoveObj1>().flameHit == true)
            {
                flame.gameObject.SetActive(true);
                count += Time.deltaTime;

                // �o�ߎ��Ԃ��߂����烊�Z�b�g
                if (count > 5.0f)
                {
                    Destroy(Obj.gameObject);
                    Destroy(flame.gameObject);
                }
            }
        }
    }
}
