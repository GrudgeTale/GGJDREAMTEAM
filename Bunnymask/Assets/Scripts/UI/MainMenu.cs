using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private AudioSource buttonClickSFX;

    public void PlayGame()
    {
        buttonClickSFX.Play();
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        buttonClickSFX.Play();
        Application.Quit();
    }

}
