using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrader : MonoBehaviour
{
    private Tower tower;
    public float attackDamageAmount;
    public float attackSpeedAmount;
    public float healthMaxAmount;


    // Start is called before the first frame update
    void Start()
    {
        tower = GetComponent<Tower>();
    }

    /*
    public float UpgradeAttackDamage()
    {
        tower.attackDamage += attackDamageAmount;
        return tower.attackDamage;
    }
    public bool UpgradeAttackSpeed()
    {
        tower.attackDelay -= attackSpeedAmount;
        return true;
    }
    public bool UpgradeHealthMax()
    {
        tower.maxHealth += healthMaxAmount;
        return true;
    }

    */
}
