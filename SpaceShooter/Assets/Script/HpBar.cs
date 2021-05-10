using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    

    public Image _hpBar;
    public Image _shield;



    public void BarUpdate(float current)
    {
        var hp = _hpBar.GetComponent<Image>();
        hp.fillAmount = current / 100;

    }

    public void BarUpdate(float current, float max)
    {
        var _shieldHp = _shield.GetComponent<Image>();
        _shieldHp.fillAmount = current / max;
    }
}
