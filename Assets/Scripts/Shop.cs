using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseStandardTurret()
    {
        Debug.Log("Standard selected");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchaseRocketLauncher()
    {
        Debug.Log("Rocket another");
        buildManager.SetTurretToBuild(buildManager.rocketLauncherPrefab);
    }
}
