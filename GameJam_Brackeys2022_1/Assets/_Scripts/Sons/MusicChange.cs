using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChange : MonoBehaviour
{
    public bool isInTrigger = false;
    public AudioClip newTrack;

    private SoundManager soundManager;

    private void Start()
    {
        //soundManager = FindObjectOfType<SoundManager>();
        //soundManager = FindObjectOfType<DontDestroyOnLoad>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(newTrack != null)
            {
                soundManager.ChangeBGM(newTrack);
                soundManager.ChangeMasterVolume(0.1f);
            }
        }
    }
}
