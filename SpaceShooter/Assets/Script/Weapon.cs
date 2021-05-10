using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject bullet;


    private bool isEnemy;


    public void CreateBullet(Transform createPosition, float angle, bool whoIs)
    {
        isEnemy = whoIs;
        var bull = Instantiate(bullet, createPosition.position, Quaternion.identity);
        bull.transform.localRotation = Quaternion.Euler(0, 0, createPosition.localEulerAngles.z);
        var currentBullet = bull.GetComponent<Bullet>();
        currentBullet.SetSpeed(angle*(-1));
        Destroy(bull, 4f);

    }
    
}
