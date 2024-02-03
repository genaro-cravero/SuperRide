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
        StartCoroutine(PowerDuration());
    }

    public override void EndPower()
    {
        base.EndPower();
    }

    IEnumerator PowerDuration()
    {
        yield return new WaitForSeconds(duration);
        EndPower();
    }
}
