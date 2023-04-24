using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAction : IPlayerAction
{
    public float runDistance = 10.0f;

    public void PerformAction(AstronautPlayer astronautPlayer)
    {
        astronautPlayer.SetAnimation(2);
        astronautPlayer.MoveForward(runDistance);
    }
    public void Move(AstronautPlayer astronautPlayer) {}
}
