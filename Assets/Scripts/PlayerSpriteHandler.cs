using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class PlayerSpriteHandler : MonoBehaviour
{
    public SpriteRenderer sr;
    public Animator a;
    public Combat c;
    public GameObject face;
    public SpriteHover faceHover;
    public SoundeffectManager sm;

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
        face = GameObject.Find("Player/Face");
        faceHover = GameObject.Find("Player/Face").GetComponent<SpriteHover>();
        sm = GameObject.Find("SoundeffectManager").GetComponent<SoundeffectManager>();
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
                a.SetBool("IsInteractingBackwards", true);
                sm.PlayInteractSound();
                GameObject.Find("Player/Sprite").transform.position = new Vector3(GameObject.Find("Player/Sprite").transform.position.x, 1.4f, GameObject.Find("Player/Sprite").transform.position.z); GameObject.Find("Player/Sprite").transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                face.SetActive(false);
                break;
            case ("Bat"):
                sr.sprite = s2;
                a.runtimeAnimatorController = anim2 as RuntimeAnimatorController;
                GameObject.Find("Player/Sprite").transform.position = new Vector3(GameObject.Find("Player/Sprite").transform.position.x, 1.75f, GameObject.Find("Player/Sprite").transform.position.z);
                GameObject.Find("Player/Sprite").transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                face.SetActive(true);
                face.transform.localPosition = new Vector3(0, 1.5f, -0.1f);
                face.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                faceHover.UpdateStartPosition();
                break;
            case ("Tom"):
                sr.sprite = s3;
                a.runtimeAnimatorController = anim3 as RuntimeAnimatorController;
                GameObject.Find("Player/Sprite").transform.position = new Vector3(GameObject.Find("Player/Sprite").transform.position.x, 3.25f, GameObject.Find("Player/Sprite").transform.position.z); GameObject.Find("Player/Sprite").transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                face.SetActive(true);
                face.transform.localPosition = new Vector3(0, 3f, -0.25f);
                face.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                faceHover.UpdateStartPosition();
                break;
            case ("Tourabe"):
                sr.sprite = s4;
                a.runtimeAnimatorController = anim4 as RuntimeAnimatorController;
                GameObject.Find("Player/Sprite").transform.position = new Vector3(GameObject.Find("Player/Sprite").transform.position.x, 1.75f, GameObject.Find("Player/Sprite").transform.position.z); GameObject.Find("Player/Sprite").transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                face.SetActive(true);
                face.transform.localPosition = new Vector3(0.75f, 1f, -0.1f);
                face.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                faceHover.UpdateStartPosition();
                break;
        }
    }
}
