using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DailyBonusManager : MonoBehaviour, IInitialize
{
    public UnityEvent<int> TicketsChanged;
    public UnityEvent<int> CurrentDayChanged;

    public int CurrentDayNumber
    {
        get { return _currentDayNumber; }
    }

    [SerializeField] private DailyBonusViewController _daylyBonusViewController;
    [SerializeField] private int _lastRewardValue;

    [SerializeField] private DailyReward[] _allDailyRewards;

    private int _currentDayNumber;
    private bool _isLastRewardRecived;

    public void Init()
    {
        foreach (var dailyReward in _allDailyRewards)
        {
            dailyReward.RewardRecived.AddListener(GetReward);
        }

        CheckPosibilityAllRewardReciever();
        CurrentDayChanged.AddListener(_daylyBonusViewController.UpdateProgressbar);
        CurrentDayChanged.Invoke(_currentDayNumber);
    }

    public void GetReward(DailyReward dailyReward)
    {
        TicketsChanged?.Invoke(dailyReward.RewardSize);
        _daylyBonusViewController.ShowCongratsView(dailyReward.DayNumber, dailyReward.RewardSize);

        dailyReward.IsRewardRecived = true;

        if (dailyReward.DayNumber == 7)
        {
            _isLastRewardRecived = true;
        }
    }

    public void CheckPosibilityAllRewardReciever()
    {
        foreach (var dailyReward in _allDailyRewards)
        {
            CheckPosibilityRewardReciever(dailyReward);
        }
    }

    public void ChangeNumberCurrentDay()
    {
        if (_isLastRewardRecived)
        {
            RestartDailyBonusManager();
        }

        _currentDayNumber++;

        if (_currentDayNumber > 7)
        {
            _currentDayNumber = 7;
            CurrentDayChanged?.Invoke(CurrentDayNumber);

            return;
        }

        CurrentDayChanged?.Invoke(CurrentDayNumber);

        CheckPosibilityAllRewardReciever();
    }

    private void RestartDailyBonusManager()
    {
        _currentDayNumber = 0;
        _isLastRewardRecived = false;

        foreach (var dailyReward in _allDailyRewards)
        {
            dailyReward.IsRewardRecived = false;
            dailyReward.SetNotActive();
        }

        CheckPosibilityAllRewardReciever();
    }

    private void CheckPosibilityRewardReciever(DailyReward dailyReward)
    {
        if (!dailyReward.IsRewardRecived && dailyReward.DayNumber <= _currentDayNumber)
        {
            dailyReward.SetActive();
        }
    }
}
