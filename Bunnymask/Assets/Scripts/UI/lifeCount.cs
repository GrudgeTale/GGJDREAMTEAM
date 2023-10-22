using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lifeCount : MonoBehaviour
{
    public GameManager gameManager;
    public Text lifeCounter;

    void Update()
    {
        lifeCounter.text = gameManager.lives.ToString() + "x";
    }
}
