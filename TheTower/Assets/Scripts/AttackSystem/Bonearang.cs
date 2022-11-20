using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonearang : Attack
{
    [SerializeField] private RuntimeSetEnemies enemies;
    [SerializeField] private float range;
    [SerializeField] private float speed;
    [SerializeField] private int bouncesMax;
    private int bounces = 0;
    private Combatant previousTarget;
    private Combatant target;

    public void Initialize(Combatant previous)
    {

        previousTarget = previous;
        FindTarget();
    }

    private void FindTarget()
    {
        for (int i = enemies.items.Count - 1; i >= 0; i--)
        {
            if (enemies.items[i] != previousTarget &&
                Vector2.Distance(transform.position, enemies.items[i].transform.position) <= range)
            {
                target = enemies.items[i];
                break;
            }
        }
        //If no valid target found, finish the attack
        if (target == null)
        {
            Finished();
        }
    }

    protected override void UpdateAttackStatus()
    {
        if (target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);
            if (Vector2.Distance(transform.position, target.transform.position) <= 0.5f)
            {
                DealDamage(target);
                if (bounces == bouncesMax)
                {
                    Finished();
                }
                else
                {
                    bounces++;
                    previousTarget = target;
                    FindTarget();
                }
            }
        }
        else
        {
            FindTarget();
        }
    }
}
