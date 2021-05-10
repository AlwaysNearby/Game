using System.Collections;
using System.Collections.Generic;
using UnityEngine;



struct Straight
{
    private float kX, kY, b;


    public Straight(float coefficientX, float coefficientY, float freeMember)
    {
        kX= coefficientX;
        kY = coefficientY;
        b = freeMember;
    }


    public float StraightPointCalculation(float x)
    {
        return (1 / kY) * (kX * x + b);
    }


    public float StraightPointCalculation(float x, float minX, float maxX)
    {
        return (1 / kY) * (kX * Mathf.Clamp(x, minX, maxX) + b);
    }


}




public class Gun : MonoBehaviour
{
    public float speedRotate = 10f;
    public GameObject prebafBullet;
    public Transform placeToSpawnBullet;
    public CameraController camera;
    public Transform cannonCartBarrel;


    public Vector3 CurrentFiringPoint {
        set   
        {
            firingPoint = value;
        }

        get 
        {
            return firingPoint;
        }
    }

    private Vector3 firingPoint;
    private float maxDistance;
    private float minDistance;
    private float _overheat;
    private float _reload;
    private Trajectory _trajectory;
    private Straight _linerDistanceToAngleConverter;
    private Straight _linerAngleToAngleConverter;
    private Animator _animationState;

    void Start()
    {
        _overheat = 0.75f;
        _reload = 0f;
        maxDistance = 40f;
        minDistance = 3f;
        _linerAngleToAngleConverter = new Straight(-30f, -45f, -2700f);
        _linerDistanceToAngleConverter = new Straight(35f, 37f, -3065f);
        _trajectory = FindObjectOfType<Trajectory>().GetComponent<Trajectory>();
        _animationState = FindObjectOfType<PlayerController>().GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && Time.time - _reload >= 0)
        {
            var bullet = CreateBullet(prebafBullet);
            var v = CalculateVelocity(firingPoint);
            var exampleBullet = bullet.GetComponent<Bullet>();
            exampleBullet.Velocity = v;
            FireABullet(exampleBullet);
            _reload = Time.time + _overheat;
            _animationState.SetTrigger("Attack");
        }

    }


    public void Rotate(float distance, float angleY)
    {
        var angleForCalculateToSpeed = _linerDistanceToAngleConverter.StraightPointCalculation(distance, minDistance, maxDistance);
        var angleCannon = _linerAngleToAngleConverter.StraightPointCalculation(angleForCalculateToSpeed);
        Quaternion toAngle = Quaternion.Euler(0, 0, angleForCalculateToSpeed);
        Quaternion newCannonAngle = Quaternion.Euler(0, angleCannon, 0);
        transform.rotation = Quaternion.Euler(0, angleY, transform.eulerAngles.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, toAngle, Time.deltaTime * speedRotate);
        cannonCartBarrel.localRotation = Quaternion.Slerp(cannonCartBarrel.localRotation, newCannonAngle, Time.deltaTime * speedRotate);
        _trajectory.Draw(_trajectory.CalculatePoints(transform.up * CalculateVelocity(firingPoint)));
    }



    
    private void FireABullet(Bullet bullet)
    {
        bullet.SetDiretion(transform.up);
        camera.Shake();
    }

    private GameObject CreateBullet(GameObject prebafBullet)
    {
        return Instantiate(prebafBullet, placeToSpawnBullet.position, Quaternion.identity);
    }



    private float CalculateVelocity(Vector3 point)
    {
        float x = new Vector3(point.x, 0, point.z).magnitude;
        float y = point.y;
        float angleInRadians = transform.eulerAngles.z * Mathf.PI / 180;

        var v2 = (Physics.gravity.y * x * x) / (2*(y - Mathf.Tan(angleInRadians) * x) * Mathf.Pow(Mathf.Cos(angleInRadians), 2));

        return Mathf.Sqrt(Mathf.Abs(v2));
    }

}





