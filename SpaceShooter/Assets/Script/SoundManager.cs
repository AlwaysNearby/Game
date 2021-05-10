using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance = null;
    private AudioSource _playSound;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        _playSound = GetComponent<AudioSource>();
    }







    public void PlayMusic(AudioClip clip)
    {
        _playSound.volume = 0.9f;
        _playSound.PlayOneShot(clip);
    }
   
}
