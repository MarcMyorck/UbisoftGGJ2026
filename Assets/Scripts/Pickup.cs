using UnityEngine;

public class Pickup : MonoBehaviour
{
    public SpriteRenderer sr;
    public EnemyInstantiator ei;
    public InputHandler ih;

    public Sprite s1;
    public Sprite s2;
    public Sprite s3;
    public int number = 0;
    public string comboName;
    public float stunTimer = 0f;
    public float stunDelay = 6f;

    public Pickup(string pComboName)
    {
        comboName = pComboName;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        ei = FindFirstObjectByType<EnemyInstantiator>();
        ih = FindFirstObjectByType<InputHandler>();
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        transform.GetChild(0).position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        transform.GetChild(0).rotation = Quaternion.Euler(0f, 0f, 0f);

        switch (comboName)
        {
            case ("Bat"):
                sr.sprite = s1;
                number = 1;
                break;
            case ("Tom"):
                sr.sprite = s2;
                number = 2;
                break;
            case ("Tourabe"):
                sr.sprite = s3;
                number = 3;
                break;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (stunTimer < stunDelay)
        {
            stunTimer += Time.deltaTime;
        } 
        else
        {
            if (!ih.isInteracting)
            {
                ei.SpawnNewEnemy(number, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z));
                Destroy(gameObject);
            }
        }
    }
}
