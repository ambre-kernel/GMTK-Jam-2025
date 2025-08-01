using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool limitFPS = false;
    public int targetFrameRate = 20;

    void Start()
    {
        if (limitFPS) Application.targetFrameRate = targetFrameRate;
    }
}
