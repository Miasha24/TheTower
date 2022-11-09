using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/Upgrader")]
public class Upgrader : ScriptableObject, ISerializationCallbackReceiver
{
    [Serializable]
    private class UpgraderValue
    {
        public FloatVariable target;
        public float increaseInitial;
        public float increaseCurrent;
        public UpgraderMaster valueController;
    }
    [Serializable]
    private class UpgraderCost
    {
        public float free;
        public FloatVariable coins;
        public float costInitial;
        public float costCurrent;
        public UpgraderMaster costController;
    }
    [Serializable]
    private class UpgraderType
    {
        public bool enable;
        public float amountIncrease;
        public int pauseAfter;
    }
    [Serializable]
    private class UpgraderMaster
    {
        public UpgraderType linear;
        public UpgraderType exponential;
    }

    [SerializeField]
    private int numberOfUpgrades;
    [SerializeField]
    private UpgraderValue value;
    [SerializeField]
    private UpgraderCost cost;


    [SerializeField]
    private float upgradeAmountInit, upgradeIncreaseInit, priceCurrentInit, priceIncreaseInit;
    [SerializeField]
    private bool free;
    [SerializeField]
    private FloatVariable coins, upgradeTarget;

    private float upgradeAmount, upgradeIncrease, priceCurrent, priceIncrease;
    public FloatVariable GetTarget() { return value.target; }
    public float GetPriceCurrent() { return priceCurrent; }

    public void OnAfterDeserialize()
    {
        value.increaseCurrent = value.increaseInitial;
        cost.costCurrent = cost.costInitial;
        numberOfUpgrades = 0;
    }

    public void OnBeforeSerialize()
    {
    }

    public bool Upgrade(out float newPrice, out float newStat)
    {
        newPrice = 0f;
        newStat = 0f;


        //Only upgrade if still allowed
//        if (value.)


        if (!free)
        {
            if (cost.costCurrent <= cost.coins.v)
            {
                cost.coins.v -= cost.costCurrent;
                //Only change costCurrent if it is still allowed
                if (numberOfUpgrades <= cost.costController.linear.pauseAfter)
                {

                }
                cost.costCurrent += cost.costController.linear.amountIncrease;

            }
            else
            {
                return false;
            }
        }








        if (!free)
        {
            if (coins.v >= priceCurrent)
            {
                coins.v -= priceCurrent;
                priceCurrent *= priceIncrease;
                newPrice = priceCurrent;
            }
            else
            {
                return false;
            }
        }

        upgradeTarget.v += upgradeAmount;
        upgradeAmount *= upgradeIncrease;

        newStat = upgradeTarget.v;
        return true; 
    }
}
