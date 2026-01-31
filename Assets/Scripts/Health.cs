using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject pickupPrefab;

    public float currentHealth = 1.0f;
    public float maxHealth = 1.0f;
    public float invincibilityTime = 1.0f;
    public float invincibilityTimer = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(invincibilityTimer < invincibilityTime)
        {
            invincibilityTimer += Time.deltaTime;
        }
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0 && invincibilityTimer < invincibilityTime)
        {

        }
        else
        {
            currentHealth -= damage;
            if (currentHealth <= 0.0f)
            {
                if (tag == "Player")
                {
                    //TODO
                }
                else
                {
                    if (tag == "Enemy")
                    {
                        GameObject inst = Instantiate(pickupPrefab, gameObject.transform.position, Quaternion.identity);
                        inst.GetComponent<Pickup>().comboName = gameObject.GetComponent<Combat>().comboName;
                        Destroy(gameObject);
                    }
                }
            }
            else
            {
                if (damage > 0)
                {
                    invincibilityTimer = 0f;
                }
                if (currentHealth > maxHealth)
                {
                    currentHealth = maxHealth;
                }
            }
        }
    }
}
