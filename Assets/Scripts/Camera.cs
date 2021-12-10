using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private PlayerBehavior _playerBehavior; 
    [SerializeField] private GameObject _target; 
    [SerializeField] private Vector3 _offsetPosition;
    [SerializeField] private float _cameraSpeed; 

    private Vector3 _updateOffsetPosition; 

    private void OnEnable()
    {
        _playerBehavior.HumanAddedCamera += OnHumanAdded;
        _playerBehavior.HumanDepriveCamera += OnHummanDeprive;
    }

    private void OnDisable()
    {
        _playerBehavior.HumanAddedCamera -= OnHumanAdded;
        _playerBehavior.HumanDepriveCamera -= OnHummanDeprive;
    }

    private void Start()
    {
        transform.LookAt(_playerBehavior.transform);
        _updateOffsetPosition = _offsetPosition; 
    }

    private void Update()
    {
        transform.position = GetPositionForCamera();
        if (_offsetPosition != _updateOffsetPosition)
        {
            _offsetPosition = Vector3.MoveTowards(_offsetPosition, _updateOffsetPosition, _cameraSpeed * Time.deltaTime);
        }

    }

    private void OnHumanAdded(int count)
    {
        _updateOffsetPosition += new Vector3(-0.1f, 0, -0.1f) * count;
    }

    private void OnHummanDeprive(int count)
    {
        _updateOffsetPosition -= new Vector3(-0.1f, 0, -0.1f) * count;
    }

    private Vector3 GetPositionForCamera()
    {
        return new Vector3(_playerBehavior.gameObject.transform.position.x, _target.transform.position.y, _playerBehavior.gameObject.transform.position.z) + _offsetPosition;
    }
}
