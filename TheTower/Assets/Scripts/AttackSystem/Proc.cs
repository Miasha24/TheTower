using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/Proc")]
public class Proc : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField] Attack attack;
    [SerializeField] private float procChanceInit;
    public float procChance;

    public void CallProc(Combatant combatant)
    {
        if ((Random.value * 99) < procChance)
        {
            ExecuteProc(combatant);
        }
    }

    protected void ExecuteProc(Combatant combatant)
    {
        Instantiate(attack, combatant.transform.position, Quaternion.identity).Initialize(combatant);
    }

    public void OnBeforeSerialize() { }

    public void OnAfterDeserialize()
    {
        procChance = procChanceInit;
    }
}


