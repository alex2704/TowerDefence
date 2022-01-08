using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint standardTurret;
    public TurretBlueprint rocketLauncher;
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
        Debug.Log("Rocket another");
        buildManager.SelectTurretToBuild(rocketLauncher);
    }
}
