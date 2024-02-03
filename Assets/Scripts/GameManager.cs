using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool IsPaused = false;
    public static bool IsSuperPowered = false;
    // Start is called before the first frame update
    void Start()
    {
        IsPaused = IsSuperPowered = false;

    }
}
