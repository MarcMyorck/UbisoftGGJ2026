using UnityEngine;

public class SpriteHover : MonoBehaviour
{
    public float amplitude = 0.2f; // how high it moves
    public float frequency = 1f; // how fast it moves
    private Vector3 startPos; 

    void Start() 
    { 
        startPos = transform.localPosition; 
    } 
    
    void Update() 
    { 
        float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.localPosition = startPos + new Vector3(0, yOffset, 0); 
    }
}
