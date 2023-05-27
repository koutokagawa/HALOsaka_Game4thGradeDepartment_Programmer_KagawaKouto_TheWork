using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame3 : MonoBehaviour
{
    public GameObject obj;
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
        // �I�u�W�F�N�g�̈ʒu��obj�Ɠ����ʒu�ɂ���
        flame.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z);

        if (obj.GetComponent<MoveObj3>().flameHit == true)
        {
            flame.gameObject.SetActive(true);
            count += Time.deltaTime;

            // �o�ߎ��Ԃ��߂����烊�Z�b�g
            if (count > 5.0f)
            {
                obj.gameObject.SetActive(false);
                flame.gameObject.SetActive(false);
            }
        }
    }
}
