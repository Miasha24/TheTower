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
        text.text = statName + ": " + upgrader.GetTarget().v + "\nCoins: " + upgrader.GetPriceCurrent();
    }

    public void Upgrade()
    {
        if (upgrader.Upgrade(out float newPrice, out float newStat))
        {
            text.text = statName + ": " + newStat + "\nCoins: " + newPrice;
        }
    }
}
