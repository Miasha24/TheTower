using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Combatant
{
    public FloatVariable health, healthMax, attackDamage, attackDelay, nextAttack;
    public List<Combatant> enemies = new List<Combatant>();

    // Start is called before the first frame update
    void Start()
    {
        health.v = healthMax.v;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies.Count > 0)
        {
            Attack(enemies[0]);
        }
    }

    //When enemies enters attack range
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Combatant enemy = collision.gameObject.GetComponent<Combatant>();
        enemies.Add(enemy);
    }

    protected override void OnDeath()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnKill()
    {
        enemies.Remove(enemies[0]);
    }

    public override bool TakeDamage(float amount)
    {
        health.v -= amount;

        GameObject text = Instantiate(floatingText, transform.position, Quaternion.identity);
        text.transform.GetChild(0).GetComponent<TextMesh>().text = amount.ToString();

        if (health.v <= 0)
        {
            OnDeath();
            return true;
        }
        return false;
    }

    protected override void Attack(Combatant target)
    {
        if (Time.time > nextAttack.v)
        {
            nextAttack.v = Time.time + attackDelay.v;
            if (target.TakeDamage(attackDamage.v))
            {
                OnKill();
            }
        }
    }
}
