using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/Upgrades/Stat")]
public class UpgradeStat : Upgrade
{
    public FloatVariable stat;
    public float upgradeAmount;
    public override void ApplyUpgrade()
    {
        if (!currentUpgrades.Items.Contains(this))
        {
            currentUpgrades.Items.Add(this);
        }
        stat.v += upgradeAmount;
        level++;
    }
}
