using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private string newGameLevel = "Scene1";

    public void LoadMainGame(){
        SceneManager.LoadScene(newGameLevel);
    }
}
