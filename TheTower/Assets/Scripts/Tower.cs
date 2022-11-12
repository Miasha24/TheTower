using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tower : Combatant
{
    [SerializeField]
    private FloatVariable health, healthMax, attackDamage, attackSpeed;
    [SerializeField]
    private BasicAttack basicAttack;
    private float nextAttack;
    [SerializeField]
    private List<Combatant> enemies = new List<Combatant>();

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
            if (enemies[0].dead) {
                enemies.RemoveAt(0);
            } 
            else 
            {
                Attack(enemies[0]);
            }        
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    protected override void OnKill()
    {
        enemies.Remove(enemies[0]);
    }
    public void OnKillEvent()
    {
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (enemies[i].dead)
            {
                enemies.RemoveAt(i);
            }
        }
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
        if (Time.time > nextAttack)
        {
            nextAttack = Time.time + (1 / attackSpeed.v);
            Instantiate(basicAttack, transform.position, Quaternion.identity, transform).SetTarget(target);
            /*
            if (target.TakeDamage(attackDamage.v))
            {
                OnKill();
            }
            */
        }
    }
}
