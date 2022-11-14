using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSelector : MonoBehaviour
{
    public RuntimeSetUpgrades possibleUpgrades;
    public RuntimeSetUpgrades collectedUpgrades;

    private Upgrade[] choices = new Upgrade[3];

    private void OnEnable()
    {
        Time.timeScale = 0f;
        RandomizeUpgrades();
    }

    private void RandomizeUpgrades()
    {
        for (int i = 0; i < choices.Length; i++)
        {
            int upgrade = (int)(Random.value * possibleUpgrades.Items.Count);
            choices[i] = possibleUpgrades.Items[upgrade];
        }
    }

    public void ChoseUpgrade(int upgrade)
    {

    }

}
