using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GridData _gridData;
    [SerializeField] private GridBuilder _gridBuilder;

    private void Awake()
    {
        _gridData.Initialize();
        _gridBuilder.Build(_gridData);
    }
}
