using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointJump : MonoBehaviour
{ 
    [SerializeField] private Color _changeColor; 
    private Color  _startColor;
    private Renderer _color; 

    private void Start()
    {
        _color = gameObject.GetComponent<Renderer>();
        _startColor = _color.material.color;
    }

    public void ChangeColor()
    {
        _color.material.color = _changeColor; 
    }

    public void StartColor()
    {
        _color.material.color = _startColor; 
    }
}
