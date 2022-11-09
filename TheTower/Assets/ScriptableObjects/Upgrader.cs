using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/Upgrader")]
public class Upgrader : ScriptableObject, ISerializationCallbackReceiver
{
    //Control variables
    [SerializeField]
    private bool enabled;
    [SerializeField]
    private bool free;
    [SerializeField]
    private int numberOfUpgradesCurrent;
    //Limit variables
    [SerializeField]
    private int numberOfUpgradesMax;
    [SerializeField]
    private float targetValueMax;
    [SerializeField]
    private float targetValueMin;
    //Target variables
    [SerializeField]
    private FloatVariable target;
    [SerializeField]
    private FloatVariable coins;
    //Current and initial upgrade amount for the target
    [SerializeField]
    private float targetIncreaseInit;
    [SerializeField]
    private float targetIncreaseCurrent;
    //current and initial price of the upgrader
    [SerializeField]
    private float priceInit;
    [SerializeField]
    private float priceCurrent;
    //Current and initial price increase 
    [SerializeField]
    private float priceIncreaseInit;
    [SerializeField]
    private float priceIncreaseCurrent;

    [Serializable]
    private class UpgraderGrowth
    {
        //Linear increase
        public bool linearIncreaseEnable;
        public float linearIncreaseAmount;
        public float linearIncreasegrowth;
        //Exponential increase
        public bool exponentialIncreaseEnable;
        public float exponentialIncreaseAmount;
        public float exponentialIncreaseGrowth;
    }

    [SerializeField]
    private UpgraderGrowth targetIncreaseGrowth;
    [SerializeField]
    private UpgraderGrowth coinsIncreaseGrowth;


    //Getters
    public FloatVariable GetTarget() { return target; }
    public float GetPriceCurrent() { return priceIncreaseCurrent; }


    public void OnAfterDeserialize()
    {
        numberOfUpgradesCurrent = 0;
        priceCurrent = priceInit;
        targetIncreaseCurrent = targetIncreaseInit;
        priceIncreaseCurrent = priceIncreaseInit;
    }
    public void OnBeforeSerialize() { }


    public bool Upgrade(out float newPrice, out float newStat)
    {
        newPrice = 0f;
        newStat = 0f;

        //dont do anything if upgrader disabled
        if (!enabled)
        {
            return false;
        }
        //If the upgrader is not free, check for coins before continueing
        if (!free)
        {
            if (coins.v >= priceCurrent)
            {
                //Subtract price from coins
                coins.v -= priceCurrent;
                //If a linear increase in price is enabled, add the increase to the price, and grow the increase amount to ensure next price is higher
                if (coinsIncreaseGrowth.linearIncreaseEnable)
                {
                    priceCurrent += coinsIncreaseGrowth.linearIncreaseAmount;
                    coinsIncreaseGrowth.linearIncreaseAmount += coinsIncreaseGrowth.linearIncreasegrowth;
                }
                if (coinsIncreaseGrowth.exponentialIncreaseEnable)
                {
                    priceCurrent *= coinsIncreaseGrowth.exponentialIncreaseAmount;
                    coinsIncreaseGrowth.exponentialIncreaseAmount *= coinsIncreaseGrowth.exponentialIncreaseGrowth;
                }
            }
            else
            {
                return false;
            }
        }
        //Increase target value by current increase amount
        target.v += targetIncreaseCurrent;
        //If linear and exponential growths are enabled, grow the increase amount
        if (targetIncreaseGrowth.linearIncreaseEnable)
        {
            priceCurrent += targetIncreaseGrowth.linearIncreaseAmount;
            targetIncreaseGrowth.linearIncreaseAmount += targetIncreaseGrowth.linearIncreasegrowth;
        }
        if (targetIncreaseGrowth.exponentialIncreaseEnable)
        {
            priceCurrent *= targetIncreaseGrowth.exponentialIncreaseAmount;
            targetIncreaseGrowth.exponentialIncreaseAmount *= targetIncreaseGrowth.exponentialIncreaseGrowth;
        }


        numberOfUpgradesCurrent++;
        if (numberOfUpgradesCurrent > numberOfUpgradesMax)
        {
            enabled = false;
        }
        if (target.v >= targetValueMax && targetValueMax != 0)
        {
            target.v = targetValueMax;
            enabled = false;
        }
        if (target.v <= targetValueMin && targetValueMin != 0)
        {
            target.v = targetValueMin;
            enabled = false;
        }



        return true; 
    }
}
