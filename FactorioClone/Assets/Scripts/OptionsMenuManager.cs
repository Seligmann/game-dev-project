using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenuManager : MonoBehaviour
{

    private bool isVSyncEnabled = true;
    private bool isFullscreen = true;


    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ToggleFullscreen()
    {
        isFullscreen = !isFullscreen;
        Screen.fullScreen = isFullscreen;
        Debug.Log("Fullscreen is now " + (isFullscreen ? "Enabled" : "Disabled"));
    }

    public void ToggleVSync()
    {
        isVSyncEnabled = !isVSyncEnabled;
        QualitySettings.vSyncCount = isVSyncEnabled ? 1 : 0;
        Debug.Log("VSync is now " + (isVSyncEnabled ? "Enabled" : "Disabled"));
    }
}
