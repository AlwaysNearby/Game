using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Enemy : MonoBehaviour
{

    private StateEnemy _currentState;
    private Animator _animatorController;

    [System.NonSerialized] public NavMesh2D navigator;
    [System.NonSerialized] public Transform Target;
    [System.NonSerialized] public Transform SelfTransform;
    [System.NonSerialized] public bool CanJump = false;
    [System.NonSerialized] public bool CanAttack = false;

    public void TransitionTo(StateEnemy newState)
    {
        this._currentState = newState;
        this._currentState.SetNewEnemy(this);
    }


    public void SetAnimation(string nameAnimation)
    {
        _animatorController.Play(nameAnimation);
    }


    void Start()
    {

        TransitionTo(new Melee());
        Init();
    }

    private void Init()
    {
        Target = GameObject.FindObjectOfType<Player>().transform;
        SelfTransform = GetComponent<Transform>();
        _animatorController = GetComponent<Animator>();
        navigator = GetComponent<NavMesh2D>();
    }

    private void FixedUpdate()
    {
    }

    private void Update()
    {
        _currentState.Update();
    }
}
