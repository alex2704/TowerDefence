using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notPermittedColor;
    public Vector3 positionOffset;
    public GameObject turretPlaceholder = null;

    private Renderer rend;

    [HideInInspector]
    public GameObject turret;

    [HideInInspector]
    public TurretBlueprint turretBlueprint;

    [HideInInspector]
    public bool isUpgraded = false;

    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;
        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to build");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        Destroy(turretPlaceholder);
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        turretBlueprint = blueprint;
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to uprade");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        //Destroy old turret
        Destroy(turret);

        //Build new turret
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        isUpgraded = true;

        Debug.Log("Turret upgraded");
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        Destroy(turret);
        turretBlueprint = null;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild || turret!= null)
        {
            if(turretPlaceholder != null)
            {
                Destroy(turretPlaceholder);
            }
            return;
        }

        if(buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
            if (turretPlaceholder == null && buildManager.CanBuild)
            {
                turretPlaceholder = Instantiate(buildManager.GetTurretToBuild().placeholder, GetBuildPosition(), Quaternion.identity);
            }
        } else
        {
            rend.material.color = notPermittedColor;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
        Destroy(turretPlaceholder);
    }
}
