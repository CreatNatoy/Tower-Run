using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private PlayerTower _playerTower;
    [SerializeField] private GameObject _target; 
    [SerializeField] private Vector3 _offsetPosition;
    [SerializeField] private float _cameraSpeed; 

    private Vector3 _updateOffsetPosition; 

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
        _updateOffsetPosition = _offsetPosition; 
    }

    private void Update()
    {
        //  transform.position = _playerTower.gameObject.transform.position + _offsetPosition;
        transform.position = GetPositionForCamera();
        if (_offsetPosition != _updateOffsetPosition)
        {
            _offsetPosition = Vector3.MoveTowards(_offsetPosition, _updateOffsetPosition, _cameraSpeed * Time.deltaTime);
        }

    }

    private void OnHumanAdded(int count)
    {
        //  _offsetPosition = _offsetPosition + (Vector3.up + Vector3.back) * count;
        // -6, 4.5, -5.43
        //   _updateOffsetPosition += new Vector3(-0.25f, -0.5f, -0.25f) * count; 
        _updateOffsetPosition += new Vector3(-0.1f, 0, -0.1f) * count;
    }

    private Vector3 GetPositionForCamera()
    {
        return new Vector3(_playerTower.gameObject.transform.position.x, _target.transform.position.y, _playerTower.gameObject.transform.position.z) + _offsetPosition;
    }
}
