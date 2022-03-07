using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : SingletonBase<SceneController>
{
    [SerializeField] private string nameScene;

    public void NextScene()
    {
        SceneManager.LoadScene(nameScene);
    }
}