using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTextMesh : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameManager gameManager;
    private int currentScore;

    // Update is called once per frame
    void Update()
    {
       currentScore = gameManager.Scoring; 
       scoreText.text = "Score: " + currentScore.ToString();
    }
}
