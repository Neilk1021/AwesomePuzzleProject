using UnityEngine;

public class GridBuilder : MonoBehaviour
{
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private Transform gridParent;

    public void Build(GridData gridData)
    {
        for (int x = 0; x < gridData.width; x++)
        {
            for (int y = 0; y < gridData.height; y++)
            {
                Vector3 offset = new Vector3(-gridData.width / 2f + 0.5f, -gridData.height / 2f + 0.5f, 0);
                Vector3 position = new Vector3(x, y, 0) + offset;
                
                GameObject tileObj = Instantiate(tilePrefab, position, Quaternion.identity, gridParent);

                if (gridParent != null)
                {
                    tileObj.transform.SetParent(gridParent);
                }
                
                Tile tile = tileObj.GetComponent<Tile>();
                tile.Initialize(new Vector2Int(x,y), gridData);
            }
        }
    }
    
}