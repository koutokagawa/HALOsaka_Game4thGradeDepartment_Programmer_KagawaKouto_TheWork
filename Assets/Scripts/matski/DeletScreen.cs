using System.Diagnostics;
using UnityEngine;

public class DeletScreen : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject Screen;

    private void Update()
    {
        // オブジェクトのアクティブ状態を確認する
        bool isActive = targetObject.activeSelf;

        if (isActive)
        {
            Screen.gameObject.SetActive(true);
        }
        else
        {
            Screen.gameObject.SetActive(false);
        }
    }
}