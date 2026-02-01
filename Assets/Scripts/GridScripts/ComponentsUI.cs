using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentsUI : MonoBehaviour
{
    [SerializeField] private Collider2D col;

    [SerializeField] private Vector3 startDragPosition;

    private void Start()
    {
        col = GetComponent<Collider2D>();
    }

    private void OnMouseDown()
    {
        startDragPosition = transform.position;
        transform.position = GetMousePostionInWorldSpace();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePostionInWorldSpace();
    }

    private void OnMouseUp()
    {
        col.enabled = false;
        Collider2D hitCollider = Physics2D.OverlapPoint(transform.position);
        col.enabled = true;
        if (hitCollider != null && hitCollider.TryGetComponent(out uponDrop dropArea))
        {
            dropArea.OnDrop(this);
        }
        else
        {
            transform.position = startDragPosition;
        }
    }

    public Vector3 GetMousePostionInWorldSpace()
    {
        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        p.z = 0f;
        return p;
    }
}
