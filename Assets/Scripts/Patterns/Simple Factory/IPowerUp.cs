using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPowerUp
{    public void Activate(AstronautPlayer astronautPlayer);
    public void SetPosition(Vector3 position);
}
