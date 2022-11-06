using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/FloatingTextSpawner")]
public class FloatingTextSpawner : ScriptableObject
{
    public GameObject floatingText;
    public void InitSpawnText(Vector3 position, string text, Color color, float delay)
    {
        GameObject go = Instantiate(floatingText, position, Quaternion.identity);
        TextPopup textPopup = go.transform.GetComponent<TextPopup>();
        textPopup.Initialize(text, color, delay);
    }
}
