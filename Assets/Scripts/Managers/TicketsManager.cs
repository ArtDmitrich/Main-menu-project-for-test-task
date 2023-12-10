using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TicketsManager : MonoBehaviour, IInitialize
{
    public int TicketCount 
    {
        get { return _ticketCount; }
    }
    public UnityEvent<int> TicketCountChanged;

    private int _ticketCount;

    public void Init()
    {
        TicketCountChanged?.Invoke(TicketCount);
    }

    public void ChangeTicketCount(int value)
    {
        _ticketCount += value;

        if (_ticketCount <= 0)
        {
            _ticketCount = 0;
        }

        TicketCountChanged?.Invoke(TicketCount);
    }
}
