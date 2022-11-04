using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public Upgrader upgrader;
    private Text text;

    private void Start()
    {
        text = transform.GetChild(0).GetComponent<Text>();
    }

    /*
    public void UpgradeAttackDamage()
    {
        text.text = "Attack Damage\n" + upgrader.UpgradeAttackDamage();
    }

    public void UpgradeAttackSpeed()
    {
        upgrader.UpgradeAttackSpeed();
    }

    public void UpgradeHealthMax()
    {
        upgrader.UpgradeHealthMax();
    }
    */


}
