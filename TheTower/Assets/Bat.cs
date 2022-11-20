using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Attack
{
    [SerializeField] private RuntimeSetEnemies enemies;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float duration;
    private Combatant target;
    private float attackNext;
    private float durationTime;
    private bool idle = true;
    private bool attacking = false;

    private void Start()
    {
        durationTime = Time.time + duration;
    }

    protected override void UpdateAttackStatus()
    {
        if (durationTime <= Time.time)
        {
            Finished();
        }
        if (target == null)
        {
            idle = true;
            attacking = false;
        }
        if (idle)
        {
            FindTarget();
        }
        else
        {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);
            if (!attacking)
            {
                if (Vector2.Distance(transform.position, target.transform.position) < attackRange)
                {
                    attacking = true;
                }
            }
            else
            {
                if (attackNext <= Time.time)
                {
                    attackNext = Time.time + (1 / attackSpeed);
                    DealDamage(target);
                }
            }
        }
    }

    private void FindTarget()
    {
        if (enemies.items.Count > 0)
        {
            idle = false;
            target = enemies.items[(int)(Random.value * enemies.items.Count)];
        }
        else
        {
            idle = true;
        }
    }
}
