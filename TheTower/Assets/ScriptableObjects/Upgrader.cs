using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/Upgrader")]
public class Upgrader : ScriptableObject, ISerializationCallbackReceiver
{
    public float upgradeAmountInit, upgradeIncreaseInit, priceCurrentInit, priceIncreaseInit;

    public FloatVariable coins, upgradeTarget;
    [NonSerialized]
    public float upgradeAmount, upgradeIncrease, priceCurrent, priceIncrease;

    public void OnAfterDeserialize()
    {
        upgradeAmount   = upgradeAmountInit;
        upgradeIncrease = upgradeIncreaseInit;
        priceCurrent    = priceCurrentInit;
        priceIncrease   = priceIncreaseInit;
    }

public void OnBeforeSerialize()
    {
    }

    public bool Upgrade(out float newPrice, out float newStat)
    {
        newPrice = 0f;
        newStat = 0f;
        if (coins.v >= priceCurrent)
        {
            coins.v -= priceCurrent;
            upgradeTarget.v += upgradeAmount;
            upgradeAmount *= upgradeIncrease;
            priceCurrent *= priceIncrease;

            newPrice = priceCurrent;
            newStat = upgradeTarget.v;

            return true;
        }
        return false; 
    }


}
