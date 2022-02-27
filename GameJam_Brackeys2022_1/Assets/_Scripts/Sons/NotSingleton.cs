using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotSingleton : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource effectsSource;

    SoundManager soundManager;

    

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void Update()
    {
        if(soundManager != null)
        {
            Destroy(soundManager);
        }
    }
}
