using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class SelectLevelButton : MonoBehaviour, IStateChange
{
    public UnityEvent<SelectLevelButton> LevelSelected;
    public int LevelNumber
    {
        get { return _levelNumber; }
    }

    [Min(1f)]
    [SerializeField] private int _levelNumber;

    [SerializeField] private TMP_Text _levelNumberText;
    [SerializeField] private ButtonWithChangeStates _selectLevelButton;

    private bool _isopenToSelect;

    public void Use()
    {
        if (_isopenToSelect)
        {
            LevelSelected?.Invoke(this);
        }
    }

    public void SetActive()
    {
        _isopenToSelect = true;
        _selectLevelButton.ChangeState(ButtonState.Active);
    }

    public void SetNotActive()
    {
        _isopenToSelect = false;
        _selectLevelButton.ChangeState(ButtonState.NotActive);
    }

    private void Start()
    {
        _levelNumberText.text = _levelNumber.ToString();
    }
}
