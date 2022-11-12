using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Proc : ScriptableObject
{
    [SerializeField]
    protected float procChance;

    public void CallProc(Combatant combatant)
    {
        if ((Random.value * 100) <= procChance)
        {
            ExecuteProc(combatant);
        }
    }

    protected abstract void ExecuteProc(Combatant combatant);

}


