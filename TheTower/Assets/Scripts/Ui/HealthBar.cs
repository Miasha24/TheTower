using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public Text value;
    public FloatVariable health, healthMax;


    // Update is called once per frame
    void Update()
    {
        value.text = health.v + " / " + healthMax.v;
        healthBar.fillAmount = health.v / healthMax.v;
    }
}
