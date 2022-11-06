using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    public FloatVariable coins;
    public Text text;
    void Start()
    {
        text.text = coins.v + " Coins";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = coins.v + " Coins";
    }
}
