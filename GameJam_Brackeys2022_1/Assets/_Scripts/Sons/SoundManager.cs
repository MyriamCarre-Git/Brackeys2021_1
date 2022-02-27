using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource effectsSource;
    
    
    //[SerializeField] GameObject MusicChange;
   

   // bool isNull = true;


    private void Awake()
    {
        if (Instance == null)
        {
            
            Instance = this;
            DontDestroyOnLoad(gameObject);

            /*
            if (MusicChange == null)
            {
                isNull = true;
                return;
            }
            else
            {
                isNull = false;
                //musicChange = MusicChange.GetComponent<MusicChange>();   
                //music = MusicSource.GetComponent<Music>();
            } */
        }
        else
        {
            Destroy(gameObject);
        }
    }

   
    public void PlaySound(AudioClip clip)
    {
        effectsSource.PlayOneShot(clip);
    }

    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }

    public void ChangeBGM(AudioClip music)
    {
        musicSource.Stop();
        musicSource.clip = music;
        musicSource.Play();
    }
}
