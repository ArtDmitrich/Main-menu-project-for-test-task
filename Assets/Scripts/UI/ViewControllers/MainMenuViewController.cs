using UnityEngine;

public enum Views
{
    Settengs,
    DailyBonus,
    Levels,
    Shop
}

public class MainMenuViewController : MonoBehaviour
{
    [SerializeField] private GameObject _dailyBonusView;
    [SerializeField] private GameObject _settingsView;
    [SerializeField] private GameObject _levelsView;
    [SerializeField] private GameObject _shopView;

    [SerializeField] private GameObject _dailyBonusAndSettingsBackground;
    [SerializeField] private GameObject _levelsBackground;
    [SerializeField] private GameObject _shopBackground;

    [SerializeField] private GameObject _backToMainMenuButton;

    [SerializeField] private VariableTMP_Text _ticketsCounter;

    private GameObject _currentActiveView;
    private GameObject _currentActiveBackground;

    public void OpenView(string viewName)
    {
        var view = GetViewByName(viewName);

        SetActiveBackGroung(view);
        SetActiveView(view);

        if (_currentActiveView != null)
        {
            _currentActiveView.SetActive(true);
            _backToMainMenuButton.SetActive(true);
        }

        if (_currentActiveBackground != null)
        {
            _currentActiveBackground.SetActive(true);
        }
    }

    public void CloseView()
    {
        _currentActiveView?.SetActive(false);
        _currentActiveBackground?.SetActive(false);
        _backToMainMenuButton?.SetActive(false);

        _currentActiveView = null;
        _currentActiveBackground = null;
    }

    public void UpdateTicketsCounter(int value)
    {
        _ticketsCounter?.ChangeText(value.ToString());
    }

    private Views GetViewByName(string viewName)
    {
        return viewName switch
        {
            "Settings" => Views.Settengs,
            "DailyBonus" => Views.DailyBonus,
            "Levels" => Views.Levels,
            "Shop" => Views.Shop,
            _ => throw new System.NotImplementedException(),
        };
    }

    private void SetActiveView(Views view)
    {
        _currentActiveView = view switch
        {
            Views.Settengs => _settingsView,
            Views.DailyBonus => _dailyBonusView,
            Views.Levels => _levelsView,
            Views.Shop => _shopView,
            _ => null,
        };
    }

    private void SetActiveBackGroung(Views view)
    {
        _currentActiveBackground = view switch
        { 
            Views.Settengs => _dailyBonusAndSettingsBackground,
            Views.DailyBonus => _dailyBonusAndSettingsBackground,
            Views.Levels => _levelsBackground,
            Views.Shop => _shopBackground,
            _ => null,
        };
    }
}
