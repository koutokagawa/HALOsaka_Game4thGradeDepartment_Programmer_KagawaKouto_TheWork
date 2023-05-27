using System;
using UnityEngine;

public class ScaleXOverTime : MonoBehaviour
{
    [SerializeField] private float targetScaleX = 2f;
    [SerializeField] private float duration = 1f;
    [SerializeField] private bool scaleUp = true;

    private Vector3 startScale;
    private float startTime;
    private bool hasReachedTarget = false;
    private Action onScalingComplete;

    public void BeginScaling(Action onScalingComplete, bool scaleUp)
    {
        this.onScalingComplete = onScalingComplete;
        this.scaleUp = scaleUp;
        OnEnable();
    }

    private void OnEnable()
    {
        startScale = transform.localScale;
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
            this.enabled = false;

            if (onScalingComplete != null)
            {
                onScalingComplete.Invoke();
            }
        }

        float newScaleX = scaleUp ? Mathf.Lerp(startScale.x, targetScaleX, progress) : Mathf.Lerp(startScale.x, 1f / targetScaleX, progress);
        Vector3 newScale = new Vector3(newScaleX, startScale.y, startScale.z);
        transform.localScale = newScale;
    }
}
