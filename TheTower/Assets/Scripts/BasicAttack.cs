using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : ProjectileHoming
{
    private void Update()
    {
        if (!target.dead)
        {
            float step = speed.v * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (target == collision.GetComponent<Combatant>())
        {
            OnHit();
        }
    }
    protected override void OnHit()
    {
        target.TakeDamage(damage.v);
        Destroy(gameObject);
    }

    public void SetTarget(Combatant target)
    {
        this.target = target;
    }

    public void OnKillEvent()
    {
        Debug.Log("Target dead!");
        if (target.dead)
        {
            Destroy(gameObject);
        }
    }
}
