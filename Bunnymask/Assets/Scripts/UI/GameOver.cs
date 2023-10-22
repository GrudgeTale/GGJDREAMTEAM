using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject inGameUI;

    public static bool gameOver = false;

    [SerializeField] private AudioSource buttonClickSFX;

    public void GameisOver(){
        gameOverUI.SetActive(true);
        inGameUI.SetActive(false);
    }

    public void loadMenu(){
        buttonClickSFX.Play();
        gameOverUI.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

    public void tryAgain(){
        buttonClickSFX.Play();
        gameOverUI.SetActive(false);
        SceneManager.LoadScene("GamePlay");
    }
}
