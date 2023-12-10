using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ButtonState
{
    NotActive,
    Active,
    Used
}

public class ButtonWithChangeStates : MonoBehaviour
{
    [SerializeField] private ButtonState _currentState;
    [SerializeField] private Button _button;

    [SerializeField] private Sprite _buttonNotActiveSprite;
    [SerializeField] private Sprite _buttonActiveSprite;
    [SerializeField] private Sprite _buttonUsedSprite;

    [SerializeField] private Image _currentImage;

    public void ChangeState(ButtonState newState)
    {
        if (newState == ButtonState.Active)
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }

        _currentState = newState;
        ChangeSprite();
    }

    private void ChangeSprite()
    {
        _currentImage.sprite = _currentState switch
        {
            ButtonState.NotActive => _buttonNotActiveSprite,
            ButtonState.Active => _buttonActiveSprite,
            ButtonState.Used => _buttonUsedSprite,
            _ => _buttonNotActiveSprite,
        };
    }
}
