using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAnimation : MonoBehaviour
{

    public AudioClip _explosionSound;


    public void DestroyAnimation()
    {

        GameManager.instance.DeleteLife();
    }



    public void Explosion()
    {
        SoundManager.instance.PlayMusic(_explosionSound);
    }

}
