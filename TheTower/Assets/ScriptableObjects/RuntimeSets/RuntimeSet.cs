using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RuntimeSet<T> : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField] private bool emptyOnStart;
    public List<T> items = new List<T>();
    public void Add(T t)
    {
        if (!items.Contains(t))
        {
            items.Add(t);
        }
    }
    public void Remove(T t)
    {
        if (items.Contains(t))
        {
            items.Remove(t);
        }
    }
    public void Empty()
    {
        for (int i = items.Count - 1; i >= 0; i--)
        {
            items.RemoveAt(i);
        }
    }
    public void OnAfterDeserialize()
    {
        if (emptyOnStart)
        {
            Empty();
        }
    }

    public void OnBeforeSerialize(){}


}
