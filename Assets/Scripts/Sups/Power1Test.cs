using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power1Test : SuperPower
{
    private void Update() {
        
    }
    public override void StartPower()
    {
        base.StartPower();
        _cameraHolder.SwitchCamera(_cameraHolder._virtualCameras[1]);
        StartCoroutine(PowerDuration());
    }

    public override void EndPower()
    {
        _cameraHolder.SwitchCamera(_cameraHolder._virtualCameras[0]);
    }

    IEnumerator PowerDuration()
    {
        yield return new WaitForSeconds(_duration);
        EndPower();
    }
}
