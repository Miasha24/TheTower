using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundTimer : MonoBehaviour
{
    public Image image;
    public FloatVariable currentPhaseLength, currentPhaseTime;

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = (currentPhaseLength.v - (currentPhaseTime.v - Time.time)) / currentPhaseLength.v;
    }
}
