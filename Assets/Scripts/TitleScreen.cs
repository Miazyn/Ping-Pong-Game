using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private AudioSource bgMusic;

    void Start()
    {
        VarManager.IsTitleScreen = true;
        bgMusic.Play();
    }



    public void StartGame()
    {
        SceneManager.LoadScene("Game");

    }

    public void QuitGame()
    {
        Application.Quit();

    }
}
