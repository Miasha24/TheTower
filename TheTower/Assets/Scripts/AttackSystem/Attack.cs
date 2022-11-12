using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public abstract class Attack : MonoBehaviour
{
    protected AttackTargeting targeting;
    protected AttackMovement movement;
    protected AttackPayload payload;
}

public abstract class AttackTargeting : MonoBehaviour 
{
    public abstract List<Combatant> GetTargets();
}

public class AttackTargetingSingleTarget : AttackTargeting
{
    [SerializeField]
    private Combatant target;
    public override List<Combatant> GetTargets() {
        return new List<Combatant>() {target};
    }
}
public class AttackTargetingAOE : AttackTargeting
{
    [SerializeField]
    private Combatant target;
    public override List<Combatant> GetTargets() {
        return new List<Combatant>() {target};
    }
}



public abstract class AttackMovement : MonoBehaviour 
{
    public abstract bool Move();
}
public class AttackMovementHoming : AttackMovement
{
    public override bool Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, )
        return false;
    }
}

public abstract class AttackPayload : MonoBehaviour
{

}
*/






/*
Alright, what's going on?

Jeg vil gerne have et modulært angrebssystem

For at det er muligt skal jeg opdele hvordan et angreb virker.

For at gå i gang med det vil jeg beskrive mit nuværende angreb, og derefter beskrive hvordan et AOE angreb kunne virke


----basic attack----

Instantiated with a target (+ speed and damage)

Moves homingly towards target

If other enemies are hit, ignore them

when target is reached: deal damage

if target dies before being hit, destroy basic attack


----AOE explosion----

Instantiated with target position (+ range, delay and damage)

Waits the delay, if there is any

When delay is over, deal damage to all enemies



----DIFFERENCES----

Transform to follow  vs  a static point
(Could be solved by inputting the attack with a position)

Hit chosen enemy  vs  hit all enemies

An attack could have functions like 

UpdateAttack: inherited to mean movement / delay
UpdateTargets: Used to change who takes damage
DealDamage: Goes through all targets and deals damage to them


*/


public abstract class Attack : MonoBehaviour
{
    [SerializeField]
    private FloatVariable damage;
    protected abstract void UpdateAttackStatus();

    protected void DealDamage(List<Combatant> targets) {
        for (int i = targets.Count - 1; i >= 0; i--)
        {
            targets[i].TakeDamage(damage.v);
        }
    }
    protected void Finished()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        UpdateAttackStatus();
    }
}

