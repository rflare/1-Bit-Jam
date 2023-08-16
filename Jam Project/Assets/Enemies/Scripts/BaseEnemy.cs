using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    //Public Properties, Getter and Setters
    public int Health {get; set;}

    //Methods
    void Update()
    {
        ManageHealth();
        Behaviour();
    }
    void ManageHealth()
    {
        if (Health <= 0) Destroy(gameObject);
    }


    protected abstract void Behaviour();


}
