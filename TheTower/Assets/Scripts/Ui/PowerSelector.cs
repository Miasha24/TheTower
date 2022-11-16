using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerSelector : MonoBehaviour
{
    public RuntimeSetUpgrades possibleUpgrades;
    public RuntimeSetUpgrades collectedUpgrades;
    public Text[] texts;

    private Upgrade[] choices = new Upgrade[3];


    public void EnablePowerSelector()
    {
        Time.timeScale = 0f;
        gameObject.SetActive(true);
        RandomizeUpgrades();
    }


    private void RandomizeUpgrades()
    {
        for (int i = 0; i < choices.Length; i++)
        {
            int upgrade = (int)(Random.value * possibleUpgrades.items.Count);
            choices[i] = possibleUpgrades.items[upgrade];
            texts[i].text = choices[i].upgradeName;
        }
    }

    public void ChoseUpgrade(int upgrade)
    {
        Debug.Log("Upgrade " + upgrade + " clicked!");
        choices[upgrade].ApplyUpgrade();
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

}
