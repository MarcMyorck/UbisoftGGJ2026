using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float duration = 3f;
    public float magnitude = 0.1f;

    private Vector3 originalPos;

    void Start()
    {
        originalPos = transform.localPosition;
    }

    public void Shake()
    {
        StopAllCoroutines();
        StartCoroutine(DoShake());
    }

    public void StopShake()
    {
        StopAllCoroutines();
    }

    IEnumerator DoShake()
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = originalPos + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
