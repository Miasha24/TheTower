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
        Debug.Log("Upgrade button pressed");
        if (upgrader.Upgrade(out float newPrice, out float newStat))
        {
            Debug.Log("Upgrade success");
            text.text = statName + ": " + newStat + "\nCoins: " + newPrice;
        }
    }
}
