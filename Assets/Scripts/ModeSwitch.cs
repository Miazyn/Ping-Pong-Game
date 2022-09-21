using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSwitch : MonoBehaviour
{

    public GameObject options, textfield;

    public void Singleplayer()
    {
        VarManager.IsSingleplayer = true;
        DisableMenu();
    }
    public void Multiplayer()
    {
        VarManager.IsSingleplayer = false;
        DisableMenu();
    }

    public void DisableMenu()
    {
        options.SetActive(false);
        textfield.SetActive(false);
        VarManager.HasGameStarted = true;
        VarManager.IsGameRunning = true;
        Debug.LogError(VarManager.HasGameStarted);
    }

}
