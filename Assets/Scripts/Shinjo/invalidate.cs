using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Invalidate : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToInvalidate;

    // Start is called before the first frame update
    private void OnEnable()
    {
        foreach (GameObject obj in objectsToInvalidate)
        {
            obj.SetActive(false);
        }
    }
}
