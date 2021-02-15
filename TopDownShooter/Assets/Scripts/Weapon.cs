using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject bullet;
    public GameObject CreatePosBullet;


    [SerializeField] public bool _isEnemy;




    public void CreateBullet(Vector3 shootPos, Vector3 arrowPos)
    {
        var newBullet = Instantiate(bullet, CreatePosBullet.transform.position, Quaternion.identity);
        var setBullet = newBullet.GetComponent<Bullet>();
        var directionBullet = Camera.main.ScreenToWorldPoint(shootPos) - arrowPos;
        setBullet.SetDirection(directionBullet, _isEnemy);

    }


}
