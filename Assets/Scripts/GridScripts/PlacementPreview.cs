using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlacementPreview : MonoBehaviour
{
    [SerializeField] private PaletteManager paletteManager;
    [SerializeField] private SpriteRenderer previewSprite;
    [SerializeField] private GridManager gridManager;
    [SerializeField] private GridData gridData;
    
    private Camera _mainCamera;
    private int currentRotation = 0;
    void Awake()
    {
        previewSprite.enabled = false;
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        HandleRotation();
        UpdatePreviewSprite();
        FollowMouse();
    }

    void HandleRotation()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentRotation += 90;

            if (currentRotation >= 360)
            {
                currentRotation = 0;
            }
            
            transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);
        }
    }
    public int GetCurrentRotation()
    {
        return currentRotation;
    }
    
    void UpdatePreviewSprite()
    {
        if (!paletteManager)
        {
            return;
        }

        if (paletteManager.TrashCanSelected())
        {
            previewSprite.enabled = true;
            previewSprite.sprite = null; // get an overlay thing
            previewSprite.color = new Color(1f, 0f, 0f, 0.4f);
            return;
        }

        Sprite selectedSprite = paletteManager.GetSelectedItemSprite();

        if (selectedSprite)
        {
            previewSprite.enabled = true;
            previewSprite.sprite = selectedSprite;
            previewSprite.color = new Color(1f, 1f, 1f, 0.4f);
        }
        else
        {
            previewSprite.enabled = false;
        }
    }

    void FollowMouse()
    {
        if (!previewSprite.enabled) return;
        Vector3 mouseWorld = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0f;

        float offsetx = -gridData.width / 2f + 0.5f;
        float offsety = -gridData.height / 2f + 0.5f;
        
        int gridX = Mathf.RoundToInt(mouseWorld.y -offsety);
        int gridY = Mathf.RoundToInt(mouseWorld.x - offsetx);
        
        Vector3 snap = new Vector3(gridY, gridX, 0f) + new Vector3(offsetx, offsety, 0f);
        
        transform.position = snap;
        
    }
}
