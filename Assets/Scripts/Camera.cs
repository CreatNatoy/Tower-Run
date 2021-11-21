using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private PlayerTower _playerTower;
    [SerializeField] private Vector3 _offsetPosition;

    private void OnEnable()
    {
        _playerTower.HumanAdded += OnHumanAdded;
    }

    private void OnDisable()
    {
        _playerTower.HumanAdded -= OnHumanAdded;
    }

    private void Start()
    {
        transform.LookAt(_playerTower.transform); 
    }

    private void Update()
    {
        transform.position = _playerTower.gameObject.transform.position + _offsetPosition;
    }

    private void OnHumanAdded(int count)
    {
        //  _offsetPosition = _offsetPosition + (Vector3.up + Vector3.back) * count;
        // -6, 4.5, -5.43
        _offsetPosition += new Vector3(-0.25f, -0.5f, -0.25f) * count; 
    }
}
