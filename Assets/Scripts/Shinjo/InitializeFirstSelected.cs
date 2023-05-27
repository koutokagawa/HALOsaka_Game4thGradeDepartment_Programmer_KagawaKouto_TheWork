using UnityEngine;
using UnityEngine.EventSystems;

public class InitializeFirstSelected : MonoBehaviour
{
    [SerializeField] private GameObject firstSelectedObject;    // 最初にSelectされるボタン
    private EventSystem eventSystem;

    private void Awake()
    {
        eventSystem = EventSystem.current;
    }

    private void OnEnable()
    {
        SetFirstSelected();
    }

    public void SetFirstSelected()
    {
        if (firstSelectedObject != null)    //EventSystem FirstSelectedの初期化
        {
            eventSystem.SetSelectedGameObject(firstSelectedObject);
            //this.enabled = false; // スクリプトを無効化
        }
    }
}
