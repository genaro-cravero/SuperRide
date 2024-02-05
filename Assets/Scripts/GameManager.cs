using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool IsPaused = false;
    public static bool IsSuperPowered = false;
    public static float GlobalGravity = -9.81f;

    // Start is called before the first frame update
    void Start()
    {
        IsPaused = IsSuperPowered = false;

    }
}
