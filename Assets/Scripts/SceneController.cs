using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private string nameScene;

    private GameController d;
    private void Start()
    {
        d = FindObjectOfType<GameController>();
        d.DontDestr();
        d.EndLevel += Instance_EndLevel;
    }

    private void Instance_EndLevel()
    {
        Debug.Log("6");
        SceneManager.LoadScene(nameScene);
        
    }
}