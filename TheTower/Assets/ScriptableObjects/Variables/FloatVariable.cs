using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/Float")]
public class FloatVariable : ScriptableObject, ISerializationCallbackReceiver
{
    public float InitialValue;

    public float v;

    public void OnAfterDeserialize()
    {
        v = InitialValue;
    }

    public void OnBeforeSerialize()
    {
    }
}
