using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCharacterDecorator : MonoBehaviour, ICharacterColor
{
    private Color _color = Color.red;

    public void ChangeColor(Color color) {
        GetComponent<SkinnedMeshRenderer>().material.color = _color; 
    }
}
