using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBat : Upgrade
{
    [SerializeField] private Proc proc;
    [SerializeField] private FloatVariable batSpeed;
    protected override void FirstUpgrade()
    {
        proc.procChance = 20;
    }

    protected override void NormalUpgrade()
    {
        batSpeed.v += 1;
    }
}
