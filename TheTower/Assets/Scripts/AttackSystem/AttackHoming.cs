using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHoming : Attack
{
    [SerializeField]
    private FloatVariable speed;
    [SerializeField]
    private Proc proc;

    private Combatant target;


    public AttackAoe aoe;

    public void Initialize(Combatant target)
    {
        this.target = target;
    }

    public void OnKillEvent()
    {
        if (target.dead)
        {
            Destroy(gameObject);
        }
    }

    protected override void UpdateAttackStatus()
    {
        float step = speed.v * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform == target.transform)
        {
            DealDamage(new List<Combatant> { target });
            Instantiate(aoe, transform.position, Quaternion.identity).Initialize(transform.position);
            proc.CallProc(target);
            Finished();
        }
    }


}
