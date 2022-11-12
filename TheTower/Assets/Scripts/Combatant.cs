using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Combatant : MonoBehaviour
{
    public GameObject floatingText;
    public bool dead = false;
    protected abstract void OnDeath();
    protected abstract void OnKill();

    public abstract bool TakeDamage(float amount);

    protected abstract void Attack(Combatant target);
}
