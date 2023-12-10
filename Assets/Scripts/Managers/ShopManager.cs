using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShopManager : MonoBehaviour, IInitialize
{
    [SerializeField] private TicketsManager _ticketsManager;
    [SerializeField] private LevelsManager _levelsManager;
    [SerializeField] private ShopViewController _shopViewController;

    [SerializeField] private List<ShopItem> _shopItems = new List<ShopItem>();

    public void Init()
    {
        foreach (var shopItem in _shopItems)
        {
            shopItem?.TryingBuyItem.AddListener(TryBuyItem);
        }
    }

    public void BuyTicketsForMoney(int value)
    {
        _ticketsManager.ChangeTicketCount(value);
        CheckPossibilityBuyingAllItems();
    }
    public void TryBuyItem(ShopItem shopItem)
    {
        if (shopItem.PurchaseTerm == PurchaseTerms.Money)
        {
            return;
        }

        if (CheckPurchaseTerms(shopItem))
        {
            BuyItem(shopItem);
        }
    }

    public void CheckPossibilityBuyingAllItems()
    {
        foreach (var shopItem in _shopItems)
        {
            if (shopItem.IsBuyed)
            {
                continue;
            }

            if (CheckPurchaseTerms(shopItem))
            {
                shopItem.SetActive();
            }
            else
            {
                shopItem.SetNotActive();
            }
        }
    }

    private bool CheckPurchaseTerms(ShopItem shopItem)
    {   
        if (shopItem.PurchaseTerm == PurchaseTerms.MinLevelCompleted)
        {
            if (shopItem.ItemPrice <= _ticketsManager.TicketCount && shopItem.MinLevelCompleted <= _levelsManager.CurentLevelNumber)
            {
                return true;
            }

            return false;
        }
        else
        {
            if (shopItem.ItemPrice <= _ticketsManager.TicketCount)
            {
                return true;
            }

            return false;
        }
    }

    private void BuyItem(ShopItem shopItem)
    {
        shopItem.Use();

        switch (shopItem.ItemType)
        {
            case ShopItemType.Skins:
                _ticketsManager.ChangeTicketCount((int)-shopItem.ItemPrice);
                break;
            case ShopItemType.Locations:
                _ticketsManager.ChangeTicketCount((int)-shopItem.ItemPrice);
                _levelsManager.OpenNextLevel(shopItem.Value);
                break;
        }
    }    
}
