using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{
    public float timeRemaining;
    public bool timeIsRunning = true;
    public Text timeText;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        timeIsRunning = true;
        timeRemaining = gameManager.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.lives == 0){
            timeIsRunning = false;
        }
        if(timeIsRunning){
            timeRemaining = gameManager.time;
            DisplayTime(timeRemaining);
        }
    }

    void DisplayTime(float timetoDisplay){
        timetoDisplay += 1;
        float minutes = Mathf.FloorToInt(timetoDisplay / 60);
        float seconds = Mathf.FloorToInt(timetoDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
