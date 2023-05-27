using UnityEngine;

public class MoveLeftBack : MonoBehaviour
{
    [SerializeField] private GameObject objectToInvalidate;
    [SerializeField] private GameObject objectToActivate;
    [SerializeField] private float targetX;
    [SerializeField] private float duration = 1f;

    private Vector3 startPosition;
    private float startTime;
    private bool hasReachedTarget = false;

    private void OnEnable()
    {
        startPosition = transform.position;
        startTime = Time.time;
        hasReachedTarget = false;
        objectToInvalidate.SetActive(false);
        objectToActivate.SetActive(true);

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
            this.enabled = false; // スクリプトを無効化

        }

        Vector3 newPosition = Vector3.Lerp(startPosition, new Vector3(targetX, startPosition.y, startPosition.z), progress);
        transform.position = newPosition;
    }
}
