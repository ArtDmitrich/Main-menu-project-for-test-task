using TMPro;
using UnityEngine;

public class CongratsViewController : MonoBehaviour
{
    [SerializeField] private TMP_Text _dayNumber;
    [SerializeField] private TMP_Text _rewardSize;

    public void UpdateText(int dayNumber, int rewardSize)
    {
        _dayNumber.text = "DAY " + dayNumber.ToString();
        _rewardSize.text = "x" + rewardSize.ToString();
    }
}
