using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private GameObject objectToActivate;
    [SerializeField] private GameObject objectToInvalidate;
    [SerializeField] private float targetLeft;
    [SerializeField] private float duration = 1f;

    private Vector3 startPosition;
    private float startTime;
    private bool hasReachedTarget = false;

    private void Awake()
    {
        objectToActivate.SetActive(false);
        objectToInvalidate.SetActive(true);
    }

    private void OnEnable()
    {
        startPosition = transform.position;
        startTime = Time.time;
        hasReachedTarget = false;
    }

    private void Update()
    {
        if (hasReachedTarget) return;

        float elapsedTime = Time.time - startTime;
        float progress = elapsedTime / duration;

        if (progress >= 1f)
        {
            progress = 1f;
            hasReachedTarget = true;
            ActivateAndInvalidate();
            this.enabled = false; // スクリプトを無効化
        }

        Vector3 newPosition = Vector3.Lerp(startPosition, new Vector3(targetLeft, startPosition.y, startPosition.z), progress);
        transform.position = newPosition;
    }
    private void ActivateAndInvalidate()
    {
        objectToActivate.SetActive(true);
        objectToInvalidate.SetActive(false);
    }
}
