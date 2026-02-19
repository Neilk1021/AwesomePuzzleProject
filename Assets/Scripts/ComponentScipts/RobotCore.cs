using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class RobotCore : RobotComponent
{
    private List<RobotComponent> _components = new List<RobotComponent>();
    [SerializeField] GameObject temp;

    public void AddComponent(RobotComponent component)
    {
        _components.Add(component);
    }
    public void RemoveComponent(RobotComponent component)
    {
        _components.Remove(component);
    }
    public override void DestroySelf()
    {
        Debug.Log("Core cannot be deleted");
    }

    public void SpawnComponents()
    {
        GameObject child = Instantiate(temp, transform);
        child.transform.localPosition = new Vector3(1, 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(1, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnComponents();
        }
    }

}