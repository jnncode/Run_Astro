using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAction : IPlayerAction
{
    public float jumpHeight = 3.0f;

    public void PerformAction(AstronautPlayer astronautPlayer)
    {
        astronautPlayer.Jump(jumpHeight);
    }
    public void Move(AstronautPlayer astronautPlayer) {}
}
