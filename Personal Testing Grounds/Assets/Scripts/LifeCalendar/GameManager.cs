using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Tower[] towers;
    GameObject towerManager;

    private void Start()
    {
        towerManager = GameObject.Find("TowerManager");
    }

    public void BuyTower(int index)
    {
        // Check if player has enough credits
        if (towers.Length >= index)
        {
            GameObject newTower = Instantiate(towers[index].modelPrefab, towerManager.transform);
            newTower.GetComponentInChildren<TowerScript>()._selected = true;
            // Close menu
        }
    }
}

[System.Serializable]
public class Tower
{
    public string name;
    public string description;
    public float cost;
    public float damage;
    public float damageOverTime;
    public float damageOverTimeTickSpeed;
    public GameObject modelPrefab;
}
