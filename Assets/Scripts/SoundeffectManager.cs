using UnityEngine;
using UnityEngine.Audio;

public class SoundeffectManager : MonoBehaviour
{
    public AudioSource playerAudioSource;
    public AudioClip dashS;
    public AudioClip interactS;
    public AudioClip hit1S;
    public AudioClip hit2S;
    public AudioClip hit3S;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayDashSound()
    {
        playerAudioSource.PlayOneShot(dashS);
    }

    public void PlayInteractSound()
    {
        playerAudioSource.PlayOneShot(interactS);
    }

    public void StopInteractSound()
    {
        playerAudioSource.Stop();
    }

    public void PlayRandomHitSound()
    {
        int rndm = Random.Range(1, 4);

        switch (rndm)
        {
            case 1:
                playerAudioSource.PlayOneShot(hit1S);
                break;
            case 2:
                playerAudioSource.PlayOneShot(hit2S);
                break;
            case 3:
                playerAudioSource.PlayOneShot(hit3S);
                break;
            default:
                playerAudioSource.PlayOneShot(hit1S);
                break;
        }
    }
}
