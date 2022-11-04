using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Combatant
{

    public List<Combatant> enemies = new List<Combatant>();

    // Start is called before the first frame update
    void Start()
    {
        Startup();
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
}
