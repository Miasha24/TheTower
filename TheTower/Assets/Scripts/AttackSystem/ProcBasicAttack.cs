using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/Procs/BasicAttack")]
public class ProcBasicAttack : Proc
{
    [SerializeField]
    private AttackHoming attack;
    [SerializeField]
    private float radius;
    protected override void ExecuteProc(Combatant combatant)
    {
        Vector2 start = combatant.transform.position;
        Collider2D[] targets = Physics2D.OverlapCircleAll(start, radius, LayerMask.GetMask("Enemy"));
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i].transform != combatant.transform)
            {
                Instantiate(attack, start, Quaternion.identity).Initialize(targets[i].GetComponent<Combatant>());
                break;
            }
        }
    }
}
