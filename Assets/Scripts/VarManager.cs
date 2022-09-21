using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VarManager : MonoBehaviour
{
    public static bool IsSingleplayer, HasGameStarted, IsTitleScreen, IsGamePaused, IsGameRunning;

    public static int counterNumLeft, counterNumRight;

    [SerializeField] GameObject counterleft, counterright;

    [SerializeField] private AudioSource bgMusic;
    void Start()
    {
        HasGameStarted = false;
        IsGameRunning = false;
        IsSingleplayer = true;
        if (bgMusic != null)
        {
            bgMusic.Play();
        }
        counterNumLeft = 0;
        counterNumRight = 0;
    }

    void Update()
    {
        
        counterleft.gameObject.GetComponent<Text>().text = counterNumLeft.ToString();
        counterright.gameObject.GetComponent<Text>().text = counterNumRight.ToString();

        if(counterNumLeft == 10 ||counterNumRight == 10)
        {

            GameDone();

        }

    }

    void GameDone()
    {
        HasGameStarted = false;
        Debug.LogError("Game has been won");
    }



}
