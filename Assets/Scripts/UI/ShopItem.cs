using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum ShopItemType
{   
    Tickets,
    Skins,
    Locations
}

public enum PurchaseTerms
{
    Money,
    MinLevelCompleted,
    OnlyTickets
}

public class ShopItem : MonoBehaviour, IStateChange
{
    public UnityEvent<ShopItem> TryingBuyItem;

    public ShopItemType ItemType
    {
        get { return _itemType; }
    }
    public PurchaseTerms PurchaseTerm
    {
        get { return _purchaseTerm; }
    }
    public int Value
    {
        get { return _value; }
    }
    public float ItemPrice
    { 
        get { return _itemPrice; }
    }
    public int MinLevelCompleted
    {
        get { return _minLevelCompleted; }
    }
    public bool IsBuyed
    {
        get { return _isBuyed; }
    }
    [SerializeField] private ShopItemType _itemType;
    [SerializeField] private PurchaseTerms _purchaseTerm;

    [SerializeField] private string _itemName;
    [SerializeField] private int _value;
    [SerializeField] private float _itemPrice;
    [SerializeField] private int _minLevelCompleted;

    [SerializeField] private Image _itemIcon;
    [SerializeField] private Sprite _itemActiveIcon;
    [SerializeField] private Sprite _itemNotActiveIcon;

    [SerializeField] private TMP_Text _itemNameText;
    [SerializeField] private TMP_Text _minLevelCompletedText;
    [SerializeField] private TMP_Text _ticketsCountText;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private GameObject _iconTickets;
    [SerializeField] private GameObject _buyedItemIcon;

    [SerializeField] private ButtonWithChangeStates _buyButton;

    private bool _isBuyed;

    public void TryBuyItem()
    {
        TryingBuyItem?.Invoke(this);
    }

    public void Use()
    {
        if (PurchaseTerm == PurchaseTerms.Money)
        {
            return;
        }

        _buyButton?.ChangeState(ButtonState.Used);

        _priceText?.gameObject.SetActive(false);
        _iconTickets?.gameObject.SetActive(false);
        _buyedItemIcon?.gameObject.SetActive(true);
        
        _isBuyed = true;
    }   

    public void SetActive()
    {
        _buyButton?.ChangeState(ButtonState.Active);

        _priceText?.gameObject.SetActive(true);
        _iconTickets?.gameObject.SetActive(true);
        _buyedItemIcon?.gameObject.SetActive(false);

        _itemIcon.sprite = _itemActiveIcon;

        if (PurchaseTerm == PurchaseTerms.MinLevelCompleted)
        {
            _minLevelCompletedText.gameObject.SetActive(false);
        }
    }

    public void SetNotActive()
    {
        _buyButton?.ChangeState(ButtonState.NotActive);

        _priceText?.gameObject.SetActive(true);
        _iconTickets?.gameObject.SetActive(true);
        _buyedItemIcon?.gameObject.SetActive(false);

        _itemIcon.sprite = _itemNotActiveIcon;

        if (PurchaseTerm == PurchaseTerms.MinLevelCompleted)
        {
            _minLevelCompletedText.gameObject.SetActive(true);
        }
    }

    private void Start()
    {
        _itemNameText.text = _itemName;
        _priceText.text = _itemPrice.ToString();

        if (PurchaseTerm == PurchaseTerms.MinLevelCompleted)
        {
            _minLevelCompletedText.gameObject.SetActive(true);
            _minLevelCompletedText.text = "LV." + _minLevelCompleted.ToString();

            _ticketsCountText.gameObject.SetActive(false);

        }
        else if (PurchaseTerm == PurchaseTerms.Money)
        {
            _itemIcon.sprite = _itemActiveIcon;

            _minLevelCompletedText.gameObject.SetActive(false);

            _ticketsCountText.gameObject.SetActive(true);
            _ticketsCountText.text = "x" + Value.ToString();

            _iconTickets?.gameObject.SetActive(false);
            _priceText.text += "$";
        }
        else
        {
            _minLevelCompletedText.gameObject.SetActive(false);
            _ticketsCountText.gameObject.SetActive(false);
        }
    }
}
