using UnityEngine;

public class ActivateObject : MonoBehaviour
{
    [SerializeField] private GameObject objectToActivate;

    private void Awake()
    {
        enabled = false;
    }

    public void Activate()
    {
        objectToActivate.SetActive(true);
    }
}
