using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCharacterDecorator : MonoBehaviour
{
    private Color _color = Color.blue;

    public void ChangeColor(Color color) {
        GetComponent<SkinnedMeshRenderer>().material.color = _color; 
    }
}
