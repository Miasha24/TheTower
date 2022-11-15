using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerSelector : MonoBehaviour
{
    public RuntimeSetUpgrades possibleUpgrades;
    public RuntimeSetUpgrades collectedUpgrades;
    public GameObject powerSelector;
    public Text[] texts;

    private Upgrade[] choices = new Upgrade[3];
    /*
    private void OnEnable()
    {
        Time.timeScale = 0f;
        RandomizeUpgrades();
    }*/
    public void EnablePowerSelector()
    {
        Time.timeScale = 0f;
        powerSelector.SetActive(true);
        RandomizeUpgrades();
    }


    private void RandomizeUpgrades()
    {
        for (int i = 0; i < choices.Length; i++)
        {
            int upgrade = (int)(Random.value * possibleUpgrades.Items.Count);
            choices[i] = possibleUpgrades.Items[upgrade];
            texts[i].text = choices[i].upgradeName;
        }
    }

    public void ChoseUpgrade(int upgrade)
    {
        Debug.Log("Upgrade " + upgrade + " clicked!");
        choices[upgrade].ApplyUpgrade();
        Time.timeScale = 1f;
        powerSelector.SetActive(false);
    }

}
