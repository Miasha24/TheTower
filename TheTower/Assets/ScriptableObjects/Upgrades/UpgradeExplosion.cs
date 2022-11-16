using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/Upgrades/Explosion")]
public class UpgradeExplosion : Upgrade
{
    public Proc proc;
    public RuntimeSetProcs procsList;
    public override void ApplyUpgrade()
    {
        if (!currentUpgrades.items.Contains(this))
        {
            currentUpgrades.items.Add(this);
            proc.procChance = 20;
            procsList.Add(proc);
        }
        else
        {
            if (proc.procChance < 100)
            {
                proc.procChance += 20;
            }
            else
            {
                //Increase chain amount!
            }
        }
    }
}
