using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeChainAttack : Upgrade
{
    public Proc proc;
    public RuntimeSetProcs procsList;
    public override void ApplyUpgrade()
    {
        if (!currentUpgrades.Items.Contains(this))
        {
            currentUpgrades.Items.Add(this);
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
