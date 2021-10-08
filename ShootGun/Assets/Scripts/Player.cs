using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

[RequireComponent(typeof(AnimatorController), typeof(ShootingHepler))]
public class Player : MonoBehaviour, ISwitcherState
{
    [SerializeField] private ActivatorModeAttack _activator;
    [SerializeField] private Touch _input;
    [SerializeField] private Weapon _gun;

    private PlayerBaseState _currentState;
    private List<PlayerBaseState> _allStates;

    private void Awake()
    {
        var animationConroller = GetComponent<AnimatorController>();

        _allStates = new List<PlayerBaseState>()
        {
            new PlayerIdle(this, _input, animationConroller, _activator),
            new PlayerTurn(this, _input, animationConroller),
            new PlayerMover(this, _input, animationConroller, transform, 3),
            new PlayerShooter(this, _input, animationConroller, _activator, _gun, GetComponent<ShootingHepler>()),
        };
    }


    private void Start()
    { 
        _currentState = _allStates[0];
        _currentState.Start();
    }

    private void Update()
    {
        _currentState.Update();
    }

    public void Switch<T>() where T : PlayerBaseState
    {
        var state = _allStates.Find(s => s is T);
        _currentState.Stop();
        _currentState = state;
        _currentState.Start();
    }
}
