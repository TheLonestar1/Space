using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIHealth : MonoBehaviour
{
    
    [SerializeField]
    private TextMeshProUGUI _text;

    public void ShowValue(int value)
    {
        Debug.Log(value);
        _text.text = value.ToString();
    }
}
