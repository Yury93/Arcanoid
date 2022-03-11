using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalManager : MonoBehaviour
{
    [SerializeField] private Text textResult;
    [SerializeField] private string nameScene;
    private GameController gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameController>();
        gameManager.CalculateScore(textResult);
        StartCoroutine(CorRetart());
        IEnumerator CorRetart()
        {
            yield return new WaitForSeconds(4f);
            SceneManager.LoadScene(nameScene);
        }
    }
}
