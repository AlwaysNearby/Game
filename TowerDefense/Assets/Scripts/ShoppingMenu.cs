using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingMenu : MonoBehaviour
{

    [SerializeField] private Text _sale, _upgrade;
    
    private Animator _animator;
    private static readonly int Move = Animator.StringToHash("move");
    private string _upgradePattern = "Upgrade: {0}$",_salePattern = "Sale: {0}$";
    private Tower _tower;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Open(Tower tower)
    {
        _tower = tower;
        _animator.SetBool(Move, true);
        UpdateCost(tower);
    }



    private void UpdateCost(Tower tower)
    {
        if (tower.level.current == tower.level.max)
        {
            _upgrade.text = "";
            _sale.text = tower.level.characteristicsTower[tower.level.current].saleCost.ToString();
        }
        else
        {
            _upgrade.text = String.Format(_upgradePattern,
                tower.level.characteristicsTower[tower.level.current].upgradeCost);
            _sale.text = String.Format(_salePattern, tower.level.characteristicsTower[tower.level.current].saleCost);
        }
        
    }
    

    public void Close()
    {
        _sale.text = "";
        _upgrade.text = "";
        _animator.SetBool(Move, false);
        _tower = null;
    }


    public void BuyUpgrade()
    {
        if (_tower != null && Balance.Instance.Cost >= _tower.level.characteristicsTower[_tower.level.current].upgradeCost)
        {
            Balance.Instance.Decrease(_tower.level.characteristicsTower[_tower.level.current].upgradeCost);
            _tower.IncreaseLevel();
            UpdateCost(_tower);
        }
    }

    public void Sale()
    {
        if (_tower != null)
        {
            Balance.Instance.Increase(_tower.level.characteristicsTower[_tower.level.current].saleCost);
            _tower.Destroy();
            Close();
        }
    }
}
