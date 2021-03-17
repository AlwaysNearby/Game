﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;



    [SerializeField] AudioClip clip;

    
    public void PlayClip()
    {
        audioSource.PlayOneShot(clip);
    }
}
