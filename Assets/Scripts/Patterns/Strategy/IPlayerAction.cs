using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PlayerAction Interface will control of the Walking, Running, and Jumping
public interface IPlayerAction
{
    public void PerformAction(AstronautPlayer astronautPlayer);
    public void Move(AstronautPlayer astronautPlayer);

}
