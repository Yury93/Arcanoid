using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : SingletonBase<GameManager>
{
    [SerializeField] private BrickList brickList;
    [SerializeField] private BrickList brickListAi;
    public static int scorePlayer;
    public static int scoreAI;
    public  Text textResultPlayer;
    public  Text textResultAI;
    public Text BoundaryText;
    private void Start()
    {
        BrickList.OnResult += ResultGame;
        textResultPlayer.text = 0.ToString();
        textResultAI.text = 0.ToString();

        textResultAI.enabled = true;
        textResultPlayer.enabled = true;
        BoundaryText.enabled = true;
        StartCoroutine(CorTextMask());
    }

    private void ResultGame()
    {
        textResultAI.enabled = true;
        textResultPlayer.enabled = true;
        BoundaryText.enabled = true;

        brickList = GameObject.Find("BrickList").GetComponent<BrickList>();
        brickListAi = GameObject.Find("BrickList (1)").GetComponent<BrickList>();
       
        if(brickList.Bricks.Count < brickListAi.Bricks.Count)
        {
            scorePlayer += 1;
            print($"PLAYER: {scorePlayer}");
            textResultPlayer.text = scorePlayer.ToString();
            StartCoroutine(CorTextMask());
            SceneController.Instance.NextScene();
            
            
            return;
        }
        else
        {
            scoreAI += 1;
            print($"AI: {scoreAI}");
            textResultAI.text = scoreAI.ToString();
            StartCoroutine(CorTextMask());
            SceneController.Instance.NextScene();
            return;
        }
      
    }
    IEnumerator CorTextMask()
    {
        yield return new WaitForSeconds(1);
        textResultAI.enabled = false;
        textResultPlayer.enabled = false;
        BoundaryText.enabled = false;
    }
}
