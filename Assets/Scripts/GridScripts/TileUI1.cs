using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileUI1 : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject highlight;
    
    public void Init()
    {
       if (spriteRenderer == null)
           {
            spriteRenderer = GetComponent<SpriteRenderer>();
           }
    }
    
    private void OnMouseEnter()
    {
        //highlight.SetActive(true);
        SetAlpha(0.5f);
    }
    
    private void OnMouseExit()
    {
        //highlight.SetActive(false);
        SetAlpha(1.0f);
    }
    void SetAlpha(float alpha)
    {
        Color color = spriteRenderer.color;
        color.a = alpha;  // Only change the alpha (transparency)
        spriteRenderer.color = color;
    }
}
