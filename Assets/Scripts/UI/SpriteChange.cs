using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChange : MonoBehaviour
{
    [SerializeField] private Sprite _firstSprite;
    [SerializeField] private Sprite _secondSprite;
    [SerializeField] private Image _buttonImage;

    public void ChangeSprite()
    {
        if (_buttonImage.sprite == _firstSprite)
        {
            _buttonImage.sprite = _secondSprite;
        }
        else
        {
            _buttonImage.sprite = _firstSprite;
        }        
    }
}
