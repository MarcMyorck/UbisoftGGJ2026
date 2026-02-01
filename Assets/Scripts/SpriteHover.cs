using UnityEngine;

public class SpriteHover : MonoBehaviour
{
    public float amplitude = 0.05f; // how high it moves
    public float frequency = 4f; // how fast it moves
    private Vector3 startPos; 

    void Start() 
    { 
        startPos = transform.localPosition;
        amplitude = Random.Range(0.02f, 0.08f);
        frequency = Random.Range(3f, 5f);
    } 
    
    void Update() 
    { 
        float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.localPosition = startPos + new Vector3(0, yOffset, 0); 
    }

    public void UpdateStartPosition()
    {
        startPos = transform.localPosition;
    }
}
