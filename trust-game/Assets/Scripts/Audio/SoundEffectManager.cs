using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{

    private static SoundEffectManager Instance;
    private static AudioSource audioSource;
    private static SoundEffectLibrary soundEffectLibrary;

    //UI
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            AudioSource[] audioSources = GetComponents<AudioSource>();
            audioSource = audioSources[0];
            soundEffectLibrary = GetComponent<SoundEffectLibrary>();
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public static void Play(string effectName)
    {
        AudioClip audioClip = soundEffectLibrary.GetRandomClip(effectName);
        if (audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }

   

    public static void SetVolume(float volume)
    {
        audioSource.volume = volume;
        
    }

  
}