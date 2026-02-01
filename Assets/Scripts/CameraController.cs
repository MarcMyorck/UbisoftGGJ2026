using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float followSharpness = 0.1f;

    void FixedUpdate()
    {
        // No need for the "if" - we'll practically never reach exactly 0 distance anyway.

        // Compute our exponential smoothing factor.
        float blend = 1f - Mathf.Pow(1f - followSharpness, Time.deltaTime * 30f);

        transform.position = Vector3.Lerp(
               transform.position,
               GameObject.Find("Player").transform.position + new Vector3(0, 3.4f, -6),
               blend);
    }
}
