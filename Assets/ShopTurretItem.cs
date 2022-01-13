using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTurretItem : Shop
{
    public TurretBlueprint turret;

    public void CallSelectTurret()
    {
        SelectTurret(turret);
    }
}
