using System.Collections.Generic;
using UnityEngine;

public class LevelsManager : MonoBehaviour, IInitialize
{
    public int CurentLevelNumber
    {
        get { return _currentLevelNumber; }
    }

    [SerializeField] private List<SelectLevelButton> _levelButtons = new List<SelectLevelButton>();
    [SerializeField] private LevelsViewController _levelsViewController;

    private int _currentLevelNumber;

    public void Init()
    {
        foreach (var levelButton in _levelButtons)
        {
            levelButton.LevelSelected.AddListener(StartLevel);
        }

        OpenOrCloseAllLevelsToSelect(false);
        OpenToSelectLevel(1);
    }

    public void StartLevel(SelectLevelButton selectLevelButton)
    {       
        ImitationCompletedLevel(selectLevelButton.LevelNumber);
    }

    public void OpenNextLevel(int nextLevelNumber)
    {
        OpenToSelectLevel(nextLevelNumber);
    }

    private void ImitationCompletedLevel(int levelNumber)
    {
        Debug.Log($"Level {levelNumber} complete!");

        _currentLevelNumber = levelNumber;
        OpenNextLevel(levelNumber + 1);
    }
    public void OpenOrCloseAllLevelsToSelect(bool isOpenning)
    {
        if (isOpenning)
        {
            for (int i = 0; i < _levelButtons.Count; i++)
            {
                OpenToSelectLevel(i + 1);
            }
        }
        else
        {
            for (int i = 0; i < _levelButtons.Count; i++)
            {
                CloseToSelectLevel(i + 1);
            }
        }
    }

    public void OpenToSelectLevel(int levelNumber)
    {
        if (!CheckIsValidateInputNumberLevel(levelNumber))
        {
            return;
        }

        _levelButtons[levelNumber - 1].SetActive();
    }

    private void CloseToSelectLevel(int levelNumber)
    {
        if (!CheckIsValidateInputNumberLevel(levelNumber))
        {
            return;
        }

        _levelButtons[levelNumber - 1].SetNotActive();
    }

    private bool CheckIsValidateInputNumberLevel(int levelNumber)
    {
        if (levelNumber <= 0 || levelNumber > _levelButtons.Count)
        {
            return false;
        }

        return true;
    }
}
