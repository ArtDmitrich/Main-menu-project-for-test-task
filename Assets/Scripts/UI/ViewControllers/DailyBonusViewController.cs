using UnityEngine;
using UnityEngine.Events;

public class DailyBonusViewController : MonoBehaviour
{
    [SerializeField] private GameObject _everydayProgressView;
    [SerializeField] private GameObject _congratsView;

    [SerializeField] private Progressbar _progressbar;

    public void ShowCongratsView(int dayNumber, int rewardSize)
    {
        _congratsView.GetComponent<CongratsViewController>().UpdateText(dayNumber, rewardSize);

        _everydayProgressView.SetActive(false);
        _congratsView.SetActive(true);
    }

    public void UpdateProgressbar(int currentDayNumber)
    {
        _progressbar.ChangeValue(currentDayNumber);
    }

    private void ShowEverydayProgressView()
    {
        _everydayProgressView.SetActive(true);
        _congratsView.SetActive(false);
    }

    private void OnEnable()
    {
        ShowEverydayProgressView();
    }    
}
