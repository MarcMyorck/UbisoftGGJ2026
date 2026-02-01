using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class PlayerSpriteHandler : MonoBehaviour
{
    public SpriteRenderer sr;
    public Animator a;
    public Combat c;

    public Sprite s1;
    public Sprite s2;
    public Sprite s3;
    public Sprite s4;

    public RuntimeAnimatorController anim1;
    public RuntimeAnimatorController anim2;
    public RuntimeAnimatorController anim3;
    public RuntimeAnimatorController anim4;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GameObject.Find("Player/Sprite").GetComponent<SpriteRenderer>();
        a = GameObject.Find("Player/Sprite").GetComponent<Animator>();
        c = GameObject.Find("Player").GetComponent<Combat>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeSprite()
    {
        switch (c.comboName)
        {
            case ("Ghost"):
                sr.sprite = s1;
                a.runtimeAnimatorController = anim1 as RuntimeAnimatorController;
                GameObject.Find("Player/Sprite").transform.position = new Vector3(GameObject.Find("Player/Sprite").transform.position.x, 1.4f, GameObject.Find("Player/Sprite").transform.position.z); GameObject.Find("Player/Sprite").transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                break;
            case ("Bat"):
                sr.sprite = s2;
                a.runtimeAnimatorController = anim2 as RuntimeAnimatorController;
                GameObject.Find("Player/Sprite").transform.position = new Vector3(GameObject.Find("Player/Sprite").transform.position.x, 1.75f, GameObject.Find("Player/Sprite").transform.position.z);
                GameObject.Find("Player/Sprite").transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                break;
            case ("Tom"):
                sr.sprite = s3;
                a.runtimeAnimatorController = anim3 as RuntimeAnimatorController;
                GameObject.Find("Player/Sprite").transform.position = new Vector3(GameObject.Find("Player/Sprite").transform.position.x, 3.25f, GameObject.Find("Player/Sprite").transform.position.z); GameObject.Find("Player/Sprite").transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                break;
            case ("Tourabe"):
                sr.sprite = s4;
                a.runtimeAnimatorController = anim4 as RuntimeAnimatorController;
                GameObject.Find("Player/Sprite").transform.position = new Vector3(GameObject.Find("Player/Sprite").transform.position.x, 1.75f, GameObject.Find("Player/Sprite").transform.position.z); GameObject.Find("Player/Sprite").transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                break;
        }
    }
}
