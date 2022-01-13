using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Shop : MonoBehaviour
{
    public List<TurretBlueprint> turrets;
    public TurretBlueprint standardTurret;
    public TurretBlueprint rocketLauncher;
    public TurretBlueprint laserBeamer;
    public ShopTurretItem shopTurretItem;
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
        foreach (var item in turrets)
        {
            shopTurretItem.turret = item;
            shopTurretItem.GetComponent<Image>().sprite = item.image;
            shopTurretItem.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>().text = "$" + item.cost;
            var go = Instantiate(shopTurretItem);
            go.transform.parent = gameObject.transform;
        }
    }

    public void SelectTurret(TurretBlueprint turretBlueprint)
    {
        buildManager.SelectTurretToBuild(turretBlueprint);
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectRocketLauncher()
    {
        Debug.Log("Rocket selected");
        buildManager.SelectTurretToBuild(rocketLauncher);
    }

    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer selected");
        buildManager.SelectTurretToBuild(laserBeamer);
    }
}
