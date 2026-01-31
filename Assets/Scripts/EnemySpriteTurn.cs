using UnityEngine;

public class EnemySpriteTurn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.rotation = Quaternion.Inverse(transform.parent.rotation) * transform.rotation;
    }
}
