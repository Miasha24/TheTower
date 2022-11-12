using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Combatant : MonoBehaviour
{
    public GameObject floatingText;
    public bool dead = false;
    protected abstract void OnDeath();
    protected abstract void OnKill();

    public abstract bool TakeDamage(float amount);/*
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
    }*/

    protected abstract void Attack(Combatant target);/*
    {
        if (Time.time > nextAttack)
        {
            nextAttack = Time.time + attackDelay;
            if (target.TakeDamage(attackDamage))
            {
                OnKill();
            }
        }
    }*/
}
