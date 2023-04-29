using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowCharacterDecorator : MonoBehaviour
{
    private Color _color = Color.yellow;

    public void ChangeColor(Color color) {
        GetComponent<SkinnedMeshRenderer>().material.color = _color; 
    }
}
