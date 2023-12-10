using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DailyReward : MonoBehaviour, IStateChange
{
    public UnityEvent<DailyReward> RewardRecived;
    public int DayNumber
    {
        get { return _dayNumber; }
    }
    public int RewardSize
    {
        get { return _rewardSize; }
    }
    public bool IsRewardRecived { get; set; }

    [Range(1f, 7f)]
    [SerializeField] private int _dayNumber;

    [Min(0f)]
    [SerializeField] private int _rewardSize;

    [SerializeField] private TMP_Text _dayNumberText;
    [SerializeField] private TMP_Text _rewardSizeText;

    [SerializeField] private ButtonWithChangeStates _rewardButton;

    public void Use()
    {
        RewardRecived?.Invoke(this);
        //IsRewardRecived = true;
        _rewardButton.ChangeState(ButtonState.Used);
    }

    public void SetActive()
    {
        _rewardButton.ChangeState(ButtonState.Active);
    }

    public void SetNotActive()
    {
        //IsRewardRecived = false;
        _rewardButton.ChangeState(ButtonState.NotActive);
    }

    private void Start()
    {
        _dayNumberText.text = "DAY" + _dayNumber;
        _rewardSizeText.text = "x" + _rewardSize;

        SetNotActive();
    }
}
