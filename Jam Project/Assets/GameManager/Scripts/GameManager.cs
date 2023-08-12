using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public fields and Getters and Setters
    //Get Singleton
    public static GameManager Instance {get; private set;}

    //methods
    private void Awake()
    {
        /*

        Destroy other GameManager instances

        */
        if(Instance != null && Instance != this)
            Destroy(this);
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void DoAMessage()
    {
        Debug.Log("Access");
    }
}
