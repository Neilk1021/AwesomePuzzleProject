using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteData : MonoBehaviour
{
    public int height = 1;
    public int width = 5;
    public Sprite[] sprites;
    public RobotComponentType[] componentTypes;


    public RobotComponentType GetTypeForPosition(Vector2Int pos)
    {
        int index = pos.y * width + pos.x;

        if (componentTypes != null && index >= 0 && index < componentTypes.Length)
        {
            return componentTypes[index];
        }

        return RobotComponentType.None;
    }
    
    public Sprite GetSpriteForPosition(Vector2Int pos)
    {
        int index = pos.y * width + pos.x;
        if (sprites != null && index < sprites.Length)
            return sprites[index];
        return null;
    }

    public bool TrashCanCheck(Vector2Int pos)
    {
        return pos.x == (width - 1);
    }
    
}
