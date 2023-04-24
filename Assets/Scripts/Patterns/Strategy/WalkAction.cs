using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAction : IPlayerAction
{
    public float walkDistance = 5.0f;

    public void PerformAction(AstronautPlayer astronautPlayer) {
        astronautPlayer.SetAnimation(1);
        astronautPlayer.MoveForward(walkDistance);
    }
    public void Move(AstronautPlayer astronautPlayer) {
        // Update the movement direction based on the current transform
        if (astronautPlayer.controller.isGrounded) {
            float verticalInput = Input.GetAxis("Vertical");
            astronautPlayer.moveDirection = astronautPlayer.transform.forward * verticalInput * astronautPlayer.speed;
        }
    }
}
