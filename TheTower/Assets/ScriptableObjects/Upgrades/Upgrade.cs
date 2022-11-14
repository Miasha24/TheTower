using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade : ScriptableObject
{
    [SerializeField] private int rarity;
    public RuntimeSetUpgrades currentUpgrades;
    public abstract void ApplyUpgrade();
}
