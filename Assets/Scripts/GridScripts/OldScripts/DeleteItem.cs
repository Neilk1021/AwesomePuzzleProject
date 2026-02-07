using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteItem : MonoBehaviour, uponDrop
{
   [SerializeField] private ComponentsUI objectToSpawn;

   public void OnDrop(ComponentsUI component)
   {
      Destroy(component.gameObject);
      Instantiate(objectToSpawn, transform.position, transform.rotation);
   }
}
