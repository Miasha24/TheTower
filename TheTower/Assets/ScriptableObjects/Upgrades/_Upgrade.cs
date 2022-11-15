using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade : ScriptableObject
{
    public string upgradeName;
    [SerializeField] private int rarity;
    public int level = 0;
    public RuntimeSetUpgrades currentUpgrades;
    public abstract void ApplyUpgrade();
}
