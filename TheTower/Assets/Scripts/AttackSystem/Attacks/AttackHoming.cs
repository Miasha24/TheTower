using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHoming : Attack
{
    [SerializeField] private FloatVariable speed;
    [SerializeField] private RuntimeSetProcs procs;

    private Combatant target;
    private const float hitDistance = 0.5f;

    public override void Initialize(Combatant target)
    {
        this.target = target;
    }

    protected override void UpdateAttackStatus()
    {
        if (target != null)
        {
            float step = speed.v * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);
            if (Vector2.Distance(transform.position, target.transform.position) <= hitDistance)
            {
                DealDamage(target);
                foreach (Proc proc in procs.items)
                {
                    proc.CallProc(target);
                }
                Finished();
            }
        }
        else
        {
            Finished();
        }
    }



}
