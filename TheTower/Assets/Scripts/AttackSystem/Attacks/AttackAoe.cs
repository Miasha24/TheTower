using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAoe : Attack
{
    [SerializeField]
    private FloatVariable size;
    [SerializeField]
    private FloatVariable delay;
    [SerializeField]
    private Collider2D col;
    private float detonateTime;

    public override void Initialize(Combatant combatant)
    {
        transform.position = combatant.transform.position;
        transform.localScale = new Vector2(size.v, size.v);
        detonateTime = Time.time + delay.v;
    }

    protected override void UpdateAttackStatus()
    {
        if (Time.time >= detonateTime)
        {
            //Create a list of combatants to return
            List<Combatant> targets = new List<Combatant>();

            //Create a filter for the overlap function
            ContactFilter2D filter = new ContactFilter2D();
            filter.SetLayerMask(LayerMask.GetMask("Enemy"));

            //Create array to hold output from overlap function
            Collider2D[] hitsArray = new Collider2D[20];

            //Call overlap function and save number of hits
            int hitsAmount = col.OverlapCollider(filter, hitsArray);

            //For each hit, see if the GameObject is an enemy
            for (int i = 0; i < hitsAmount; i++)
            {
                if (hitsArray[i].TryGetComponent<Combatant>(out Combatant target))
                {
                    targets.Add(target);
                }        
            }
            //Return all enemies
            if (targets.Count > 0) {
                DealDamage(targets);
            }

            //Call finished
            Finished();
        }
    }
}
