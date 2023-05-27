using UnityEngine;
using UnityEngine.EventSystems;

public class InitializeFirstSelected : MonoBehaviour
{
    [SerializeField] private GameObject firstSelectedObject;    // �ŏ���Select�����{�^��
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
        if (firstSelectedObject != null)    //EventSystem FirstSelected�̏�����
        {
            eventSystem.SetSelectedGameObject(firstSelectedObject);
            //this.enabled = false; // �X�N���v�g�𖳌���
        }
    }
}
