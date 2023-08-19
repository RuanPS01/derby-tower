using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSceneLogic : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0f;
    }

    public void StartGameScene()
    {
        Time.timeScale = 1f;
    }
}
