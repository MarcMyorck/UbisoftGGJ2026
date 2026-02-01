using UnityEngine;

public class Health : MonoBehaviour
{
    public GameManager gm;
    public GameObject player;

    public GameObject pickupPrefab;

    public float currentHealth = 1.0f;
    public float maxHealth = 1.0f;
    public float invincibilityTime = 1.0f;
    public float invincibilityTimer = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = Object.FindFirstObjectByType<GameManager>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(invincibilityTimer < invincibilityTime)
        {
            invincibilityTimer += Time.deltaTime;
            //GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
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
                    if (player.GetComponent<Combat>().comboName != "Ghost")
                    {
                        player.GetComponent<Combat>().comboName = "Ghost";
                        player.GetComponent<Combat>().AssignAttackCombo();
                        currentHealth = maxHealth;
                        invincibilityTimer = 0f;
                    }
                    else
                    {
                        gm.GameOver();
                    }
                }
                else
                {
                    if (tag == "Enemy")
                    {
                        if (player.GetComponent<Combat>().comboName == "Ghost")
                        {
                            GameObject inst = Instantiate(pickupPrefab, gameObject.transform.position, Quaternion.identity);
                            inst.GetComponent<Pickup>().comboName = gameObject.GetComponent<Combat>().comboName;
                            Destroy(gameObject);
                        } 
                        else
                        {
                            Destroy(gameObject);
                        }
                        
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
