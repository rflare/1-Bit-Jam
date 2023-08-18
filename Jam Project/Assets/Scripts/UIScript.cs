using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public void SwitchScene()
    {
        GameManager.Instance.SwitchScene();
    }

    public void ReloadScene()
    {
        GameManager.Instance.ReloadScene();
    }
}
