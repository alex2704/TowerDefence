using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;
    
    public GameObject upgradedPrefab;
    public int upgradeCost;
    public Sprite image;
    public GameObject placeholder;

    public int GetSellAmount()
    {
        return cost / 2;
    }
}
