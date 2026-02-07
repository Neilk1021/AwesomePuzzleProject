using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Component
{

    public int Health;
    public string Name;
    public float Xspeed;
    public float Yspeed;
    public float Cost;
    public bool Isdestroyed;
    //public int Weight;
    //public Vector3 Position;
    //public Color Color;
    //public int Powerconsume;

    public Component(int health, string name, float xspeed, 
        float yspeed, float cost, bool isDestroyed)
    {
        Health = health;
        Name = name;
        Xspeed = xspeed;
        Yspeed = yspeed;
        Cost = cost;
        Isdestroyed = isDestroyed;
    }

    void DamageComponent(int damage)
    {
        Health -= damage;
    }

    void HealComponent(int health)
    {
        Health += health;
    }
    
    float ApplyForceX(float x)
    {
        return x * Xspeed;
    }

    float ApplyForceY(float y)
    {
        return y * Yspeed;
    }

    void OnDestroy()
    {
        
    }
    
    /*float ConsumePower(float amount)
    {
        return amount * powerConsumptionRate;
    }*/
}

//Use [SerializeField] on private objects
//Use ScriptableObject for the grid system