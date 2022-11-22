using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Attack : MonoBehaviour
{
    [SerializeField]
    private FloatVariable damage;
    protected abstract void UpdateAttackStatus();
    public abstract void Initialize(Combatant combatant);

    protected void DealDamage(List<Combatant> targets) {
        for (int i = targets.Count - 1; i >= 0; i--)
        {
            targets[i].TakeDamage(damage.v);
        }
    }
    protected void DealDamage(Combatant target)
    {
        target.TakeDamage(damage.v);
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

