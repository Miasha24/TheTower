using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Proc : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField]
    private float procChanceInit;
    public float procChance;

    public void CallProc(Combatant combatant)
    {
        if ((Random.value * 100) <= procChance)
        {
            ExecuteProc(combatant);
        }
    }

    protected abstract void ExecuteProc(Combatant combatant);

    public void OnBeforeSerialize() { }

    public void OnAfterDeserialize()
    {
        procChance = procChanceInit;
    }
}


