using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField]
    protected FloatVariable damage;
    [SerializeField]
    protected FloatVariable speed;

    protected abstract void OnHit();


}

public abstract class ProjectileHoming : Projectile
{
    protected Combatant target;
}

public abstract class ProjectileDirection : Projectile
{
    protected Vector2 direction;
    protected float maxDistance;
}

