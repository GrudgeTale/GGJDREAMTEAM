using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public GameManager gameManager;
    private int currentScore;

    // Update is called once per frame
    void Start(){
        currentScore = gameManager.Scoring;
        scoreText.text = "SCORE: " + gameManager.Scoring.ToString();
    }

    void Update()
    {
        if(gameManager.Scoring > currentScore){
            scoreText.text = "SCORE: " + gameManager.Scoring.ToString();
        }
        currentScore = gameManager.Scoring;
    }
}
