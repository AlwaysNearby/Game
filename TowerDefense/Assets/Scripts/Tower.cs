using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public abstract class Tower : MonoBehaviour
{
    [SerializeField] private TowerType _type;
    [SerializeField] private UnityEvent OnUpgrade;
    private SpriteTower _spriteTower;

    public int buildCost;
    

    [FormerlySerializedAs("Level")] public Level level;


    private void Awake()
    {
        _spriteTower = GetComponent<SpriteTower>();
    }
    
    
    
    



    public virtual void Upgrade()
    { 
        SetNewSprite(level.levelSprite[level.current]);
    }



    public void SetNewSprite(Sprite sprite)
    {
        _spriteTower.SetNewSprite(sprite);
    }

    public void IncreaseLevel()
    {

        if (level.current + 1 < level.max)
        {
            level.current += 1;
            OnUpgrade?.Invoke();
        }

    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
    

    public TowerType Type
    {
        get { return _type; }
        private set { ; }

    }
}
