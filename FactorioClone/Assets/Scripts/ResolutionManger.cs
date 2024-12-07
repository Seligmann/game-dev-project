using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
    public void SetResolution1()
    {
        Screen.SetResolution(1280, 720, FullScreenMode.Windowed);
    }
    public void SetResolution2()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
    }
}
