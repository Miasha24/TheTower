using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundTimer : MonoBehaviour
{
    public Image image;
    public GameMaster master;


    // Update is called once per frame
    void Update()
    {
        image.fillAmount = master.GetRoundTimePercent();
    }
}
