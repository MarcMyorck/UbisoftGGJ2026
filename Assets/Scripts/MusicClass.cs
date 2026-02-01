using UnityEngine;

public class MusicClass : MonoBehaviour
{
    private static MusicClass instance;
    private AudioSource _audioSource;

    private void Awake()
    {
        // If an instance already exists, destroy this duplicate 
        if (instance != null && instance != this) 
        { 
            Destroy(gameObject); 
            return; 
        } 
        
        // Otherwise, this becomes the main instance 
        instance = this; 
        DontDestroyOnLoad(gameObject); 

        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
