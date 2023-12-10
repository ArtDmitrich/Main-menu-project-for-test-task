using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private List<GameObject> _gameObjects = new List<GameObject>();

    private void Start()
    {
        foreach (var item in _gameObjects)
        {
            item?.GetComponent<IInitialize>().Init();
        }
    }
}
