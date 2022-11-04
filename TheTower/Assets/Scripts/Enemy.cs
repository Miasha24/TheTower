using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Combatant
{
    public float health, healthMax, attackDamage, attackDelay, nextAttack;

    private float speed = 4.0f;
    private Vector2 target;
    private bool attacking = false;
    private Combatant tower;

    // Start is called before the first frame update
    void Start()
    {
        health = healthMax;
        target = new Vector2(0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target, step);
        if (attacking)
        {
            Attack(tower);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Tower")
        {
            Debug.Log("Attacking Tower!");
            tower = collision.transform.GetComponent<Combatant>();
            attacking = true;
        }
    }

    protected override void OnKill()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnDeath()
    {
        Destroy(gameObject);
    }

    public override bool TakeDamage(float amount)
    {
        health -= amount;

        GameObject text = Instantiate(floatingText, transform.position, Quaternion.identity);
        text.transform.GetChild(0).GetComponent<TextMesh>().text = amount.ToString();

        if (health <= 0)
        {
            OnDeath();
            return true;
        }
        return false;
    }

    protected override void Attack(Combatant target)
    {
        if (Time.time > nextAttack)
        {
            nextAttack = Time.time + attackDelay;
            if (target.TakeDamage(attackDamage))
            {
                OnKill();
            }
        }
    }
}
