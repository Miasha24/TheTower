using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public string statName;
    public Text text;
    public Upgrader upgrader;

    private void Start()
    {
        text.text = statName + ": " + upgrader.upgradeTarget.v + "\nCoins: " + upgrader.priceCurrent;
    }

    public void Upgrade()
    {
        if (upgrader.Upgrade(out float newPrice, out float newStat))
        {
            text.text = statName + ": " + newStat + "\nCoins: " + newPrice;
        }
    }
}
