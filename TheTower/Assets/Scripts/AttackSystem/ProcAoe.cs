using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/Procs/Aoe")]
public class ProcAoe : Proc
{
    [SerializeField]
    private AttackAoe attack;

    protected override void ExecuteProc(Combatant combatant)
    {
        Instantiate(attack, combatant.transform.position, Quaternion.identity).Initialize(combatant.transform.position);
    }



}
