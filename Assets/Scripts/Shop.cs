using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint standardTurret;
    public TurretBlueprint rocketLauncher;
    public TurretBlueprint laserBeamer;
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
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
