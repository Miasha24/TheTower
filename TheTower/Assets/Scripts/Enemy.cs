using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Combatant
{
    private float health, healthMax, attackDamage, attackSpeed, nextAttack, moveSpeed, coinDropAmount;
    public FloatVariable baseAttackDamage, baseAttackSpeed, baseHealthMax, baseMovementSpeed, baseCoinDropAmount, targetCoinAmount;
    public FloatingTextSpawner textSpawner;
    [SerializeField]
    private GameEvent gameEvent;

    private Vector2 target;
    private bool attacking = false;
    private Combatant tower;

    // Start is called before the first frame update
    void Start()
    {
        healthMax = baseHealthMax.v;
        attackDamage = baseAttackDamage.v;
        attackSpeed = baseAttackSpeed.v;
        moveSpeed = baseMovementSpeed.v;
        coinDropAmount = baseCoinDropAmount.v;


        health = healthMax;
        target = new Vector2(0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        float step = moveSpeed * Time.deltaTime;
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
        //throw new System.NotImplementedException();
    }

    protected override void OnDeath()
    {
        targetCoinAmount.v += coinDropAmount;
        textSpawner.InitSpawnText(transform.position, coinDropAmount.ToString(), Color.yellow, 0.3f);
        dead = true;
        gameEvent.Raise();
        Destroy(gameObject);
    }

    public override bool TakeDamage(float amount)
    {
        health -= amount;
        textSpawner.InitSpawnText(transform.position, amount.ToString(), Color.white, 0);

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
            nextAttack = Time.time + (1 / attackSpeed);
            if (target.TakeDamage(attackDamage))
            {
                OnKill();
            }
        }
    }
}
