using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Animator anim = GetComponent<Animator>(); 
        anim.Play("PlayerIdle");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
