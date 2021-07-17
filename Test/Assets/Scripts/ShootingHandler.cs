using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShootingHandler : MonoBehaviour
{

    [SerializeField] private Transform _bulletCreationLocation;
    [SerializeField] private Bullet _bullet;

    private int _numberTargets;
    private Enemy[] _targets;
    private Camera _camera;
    
    
    public event Action OnKillAllTargets;

    public int NumberTargets
    {
        get => _numberTargets;
        set
        {
            _numberTargets = value;
        }
    }
    

    private void Start()
    {
        _camera = Camera.main;
        _numberTargets = 0;
    }


    public void ShootAt(Vector2 position)
    {
        Vector3 resultPoint = TransformPoint(position);
        var bullet = CreateBullet();
        bullet.SetVelocity(resultPoint - _bulletCreationLocation.position);
    }


    
    
    public void ReduceTargets()
    {
        _numberTargets -= 1;
        if (_numberTargets <= 0)
        {
            OnKillAllTargets?.Invoke();
        }
    }
    

    private Bullet CreateBullet()
    {
        return Instantiate(_bullet, _bulletCreationLocation.position, Quaternion.identity);
    }


    private Vector3 TransformPoint(Vector2 pointScreen)
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(pointScreen);
        Plane unitPlane = new Plane(Vector3.up, transform.position);
        float hit_dst;
        Vector3 resultPoint = Vector3.zero;
        if (unitPlane.Raycast(ray, out hit_dst))
        {
            resultPoint = ray.GetPoint(hit_dst);
        }

        return resultPoint;

    }


    private void RotateAtTarget(Enemy enemy)
    {
        transform.LookAt(enemy.transform.position);
    }
    

}
