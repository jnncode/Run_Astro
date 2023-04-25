using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFactory : MonoBehaviour
{
    public static IPowerUp CreatePowerUp(PowerUpType type)
    {
        switch (type)
        {
            case PowerUpType.Expand:
                return GameObject.FindWithTag("PowerUpFactory").AddComponent<ExpandPowerUp>();
            case PowerUpType.Shrink:
                return GameObject.FindWithTag("PowerUpFactory").AddComponent<ShrinkPowerUp>();
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
}
