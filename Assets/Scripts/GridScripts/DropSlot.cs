using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSlot : MonoBehaviour, uponDrop
{
    public void OnDrop(ComponentsUI component)
    {
        component.transform.position = transform.position;
        Debug.Log("Item dropped here");
    }
}
