using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Progressbar : MonoBehaviour
{
    [SerializeField] private int _maxValue;

    [SerializeField] private Slider _progressbar;
    [SerializeField] private TMP_Text _progressText;

    public void ChangeValue(int value)
    {
        _progressbar.value = value;
        _progressText.text = value.ToString() + $"/{_maxValue}";
    }
}
