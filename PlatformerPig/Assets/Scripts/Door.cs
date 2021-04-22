using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    private Animator _animatorController;
    private bool _canExit = true;

    public OpenEvent doorOpened;
    public AnimationClip animationClip;

    public bool CanExit
    {
        get
        {
            return _canExit;
        }
    }

    private void Awake()
    {
        _animatorController = GetComponent<Animator>();
    }


    void Start()
    {
        _animatorController.Play("idle");
    }



    public void StartOpening()
    {
        StartCoroutine(StartAnimation());
    }
    
    


    private IEnumerator StartAnimation()
    {
        _animatorController.Play("OpenAndClose");
        _canExit = false;
        yield return new WaitForSeconds(animationClip.length);
        doorOpened.Invoke(transform);
        _animatorController.Play("idle");
        yield return new WaitForSeconds(1.5f);
        _canExit = true;

    }

}


[System.Serializable]
public class OpenEvent : UnityEvent<Transform> { }
