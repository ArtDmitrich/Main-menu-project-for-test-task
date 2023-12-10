using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VariableTMP_Text : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void ChangeText(string value)
    {
        _text.text = value; 
    }
}
