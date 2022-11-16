using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "My Assets/RuntimeSetUpgrades")]
public class RuntimeSetUpgrades : RuntimeSet<Upgrade>, ISerializationCallbackReceiver
{
    [SerializeField] private bool emptyOnStart;
    public void OnAfterDeserialize()
    {
        if (emptyOnStart)
        {
            Empty();
        }
    }

    public void OnBeforeSerialize() { }
}
