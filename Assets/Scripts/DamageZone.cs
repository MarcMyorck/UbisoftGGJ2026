using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public float damage = 1.0f;
    public string belonging = "";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player" | other.tag == "Enemy") && belonging != other.tag)
        {
            other.GetComponent<Health>().TakeDamage(1.0f);
        }
    }
}
