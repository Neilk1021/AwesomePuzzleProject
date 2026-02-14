using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteData : MonoBehaviour
{
    public int height = 1;
    public int width = 5;
    public Sprite[] items;
  
    public Sprite GetSpriteForPosition(Vector2Int pos)
    {
        int index = pos.y * width + pos.x;
        if (items != null && index < items.Length)
            return items[index];
        return null;
    }
}
