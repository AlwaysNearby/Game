using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class Level
{

    public int max;
    public int current = 0;
    public Characteristic[] characteristicsTower;
    public Sprite[] levelSprite;
    public Sprite[] reloadSprite;

}
