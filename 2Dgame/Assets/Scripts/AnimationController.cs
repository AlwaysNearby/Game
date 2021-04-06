using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private Animator _play;


    private void Start()
    {
        _play = GetComponent<Animator>();
    }



    public void PlayReloadAnim(float _lastReload)
    {
        StartCoroutine(ReloadAnimation(_lastReload));
        
    }
    private IEnumerator ReloadAnimation(float _lastReload)
    {
        while (Time.time - _lastReload < 0)
        {
            _play.SetBool("Reload", true);
            yield return null;
        }

        _play.SetBool("Reload", false);
    }




    public bool StateAnimation(string nameAnimation)
    {
        var animatorStateInfo = _play.GetCurrentAnimatorStateInfo(0);
        if (animatorStateInfo.IsName(nameAnimation))
            return false;
        return true;
    }






}
