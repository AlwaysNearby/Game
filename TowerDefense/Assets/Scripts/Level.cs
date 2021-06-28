using UnityEngine;

[System.Serializable]
public class Level
{

    public int Max;
    public int Current = 0;
    public Characteristic[] CharacteristicsTower;
    public Sprite[] LevelSprite;
    public Sprite[] ReloadSprite;

}
