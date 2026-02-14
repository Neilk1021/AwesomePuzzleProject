using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteManager : MonoBehaviour
{
    [SerializeField] private PaletteData _paletteData;
    [SerializeField] private PaletteBuilder _paletteBuilder;
    
    private void Awake()
    {
        _paletteBuilder.Build(_paletteData);
    }

}
