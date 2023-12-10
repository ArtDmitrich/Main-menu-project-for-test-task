using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShopViewController : MonoBehaviour
{
    public UnityEvent CheckedPossibilityBuyingAllItems;

    private void OnEnable()
    {
        CheckedPossibilityBuyingAllItems?.Invoke();
    }
}
