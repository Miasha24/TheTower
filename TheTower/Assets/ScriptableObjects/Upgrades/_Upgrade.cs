using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade : ScriptableObject, ISerializationCallbackReceiver
{
    public string upgradeName;
    [SerializeField] protected int rarityInit;
    [SerializeField] protected int rarity;
    [SerializeField] protected int levelInit;
    [SerializeField] protected int level;
    public RuntimeSetUpgrades currentUpgrades;

    public abstract void ApplyUpgrade();

    public void OnBeforeSerialize() { }

    public void OnAfterDeserialize()
    {
        rarity = rarityInit;
        level = levelInit;
    }
}
