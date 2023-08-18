using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //private properties
    int index = 1;

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
    void Start()
    {
        if(SceneManager.sceneCount == 1) SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) ReloadScene();
    }

    public void DoAMessage()
    {
        Debug.Log("Access");
    }

    public void HeDied()
    {
        ReloadScene();
    }

    public void GotFlag()
    {
        SwitchScene();
    }
    public void SwitchScene()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetAllScenes()[1]);
        if(index == SceneManager.sceneCountInBuildSettings - 1)
        { 
            index = 1;
        }
        else
        {
            index += 1;
        }
        SceneManager.LoadScene(index, LoadSceneMode.Additive);
    }
    public void ReloadScene()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetAllScenes()[1]);
        SceneManager.LoadScene(index, LoadSceneMode.Additive);
    }
}
