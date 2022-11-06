using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPopup : MonoBehaviour
{
    public TextMesh textMesh;
    public Animator animator;
    public GameObject child;


    public void Initialize(string text, Color color, float delay)
    {
        textMesh.text = text;
        textMesh.color = color;
        if (delay > 0)
        {
            Invoke("Show", delay);
        }
        else
        {
            Show();
        }
    }

    private void Show()
    {
        child.SetActive(true);
        Destroy(gameObject, 1.0f);
    }
}
