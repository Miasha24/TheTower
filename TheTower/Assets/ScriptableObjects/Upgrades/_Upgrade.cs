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

    public void ApplyUpgrade()
    {
        if (!currentUpgrades.items.Contains(this))
        {
            currentUpgrades.items.Add(this);
            FirstUpgrade();
        }
        else
        {
            NormalUpgrade();
        }
        level++;
    }

    protected abstract void FirstUpgrade();
    protected abstract void NormalUpgrade();

    public void OnBeforeSerialize() { }

    public void OnAfterDeserialize()
    {
        rarity = rarityInit;
        level = levelInit;
    }
}
