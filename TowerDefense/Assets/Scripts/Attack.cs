
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class Attack
{


     public event Action OnStartReload;
     public event Action OnEndReload;
     
     private Level _level;
     private float _last;
     private float _endReloadTime;
     private int _currentAmmo;
     private bool _inReload;


     public Attack(Level level)
     {
          _level = level;
          Reset();
     }
     
     public void DamageTo(IHealth target)
     {
          target.Decrease(_level.CharacteristicsTower[_level.Current].Damage);
     }


     public bool AttemptShoot()
     {
          if (_currentAmmo > 0)
          {
               if (CanIShoot())
               {
                    _last = Time.time +_level.CharacteristicsTower[_level.Current].ShootingInterval; ;
                    _currentAmmo -= 1;
                    return true;
               }
          }
          else
          {
               if (!_inReload)
               {
                    _endReloadTime = Time.time + _level.CharacteristicsTower[_level.Current].ReloadTime;
                    _inReload = true;
                    OnStartReload?.Invoke();
               }
               
               Reload(Time.time, _endReloadTime);
          }

          return false;
     }


     public void Reset()
     {
          _currentAmmo = _level.CharacteristicsTower[_level.Current].Ammo;
          OnEndReload?.Invoke();
          _last = 0f;
          _endReloadTime = 0f;
          _inReload = false;
     }


     private void Reload(float currentTime, float endReloadTime)
     {
          if (endReloadTime - currentTime < 0)
          {
               _inReload = false;
               _currentAmmo = _level.CharacteristicsTower[_level.Current].Ammo;
               OnEndReload?.Invoke();
          }
     }
     
     
     private bool CanIShoot()
     {
          return Time.time - _last >= 0;
     }
     
    
}
