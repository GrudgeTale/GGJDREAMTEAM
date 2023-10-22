using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class highScore : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public GameManager gameManager;

    // Update is called once per frame
    void Update()
    {
        highScoreText.text = "Highscore: " + gameManager.highScore.ToString();
    }
}
