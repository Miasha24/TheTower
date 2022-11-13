using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiText : MonoBehaviour
{
    public string prefix;
    public string suffix;
    public Text text;
    public FloatVariable variable;


    // Start is called before the first frame update
    void Start()
    {
        text.text = prefix + variable.v + suffix;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = prefix + variable.v + suffix;
    }
}
