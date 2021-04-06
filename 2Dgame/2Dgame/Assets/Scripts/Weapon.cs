using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{

    private GameObject posForCreateBullet;
    private int currentWeapon;
    public ReloadEvent _startRecharge;

    

    private void Start()
    {
        posForCreateBullet = GameObject.Find("PosToBullet");
        currentWeapon = 0;
    }



    public virtual extern void Shoot(Vector3 target, Vector3 arrowPos);

    public virtual void StartReload(float _lastReload)
    {
        _startRecharge.Invoke(_lastReload);
    }

    

    public void CreateBullet(Vector3 direction, GameObject bulletPrebaf)
    {
        direction.z = 0;
        var bulletGameObject = Instantiate(bulletPrebaf, posForCreateBullet.transform.position, Quaternion.identity) as GameObject;
        var angle = Mathf.Atan2(direction.y, direction.x) * 180/Mathf.PI;
        bulletGameObject.transform.rotation = Quaternion.Euler(0, 0, angle);
        var bullet = bulletGameObject.GetComponent<Bullet>();
        bullet.SetDirection(direction);

    }



    public void SwitchWeapon(Weapon[] _armory)
    {
        currentWeapon = (currentWeapon + 1) % _armory.Length;
    }



    public bool CheckRecharge(float lastRecharge)
    {
        if(Time.time - lastRecharge >= 0)
        {
            return true;
        }
        return false;
    }

    public int GetWeapon()
    {
        return currentWeapon;
    }
}


[System.Serializable]
public class ReloadEvent : UnityEvent<float> { }
