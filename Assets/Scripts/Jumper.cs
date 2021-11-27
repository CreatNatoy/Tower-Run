using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private float _startJumpForce;
    private bool _isGrounded; 
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _startJumpForce = _jumpForce; 
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && _isGrounded)
        {
            _isGrounded = false; 
            _rigidbody.AddForce(Vector3.up * _jumpForce);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Road rouad))
        {
            _isGrounded = true; 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PointJump pointJump))
            {
               Tower ColliderTower = pointJump.GetComponentInParent<Tower>(); 
                ChangeJumpForse(ColliderTower.GetComponent<Tower>().GetSizeHumans());
               pointJump.ChangeColor(); 
            }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PointJump pointJump))
        {
            _jumpForce = _startJumpForce;
            pointJump.StartColor(); 
        }
    }

    private void ChangeJumpForse(int Change)
    {
        _jumpForce = _jumpForce + (Change - 1) * 10f; 
    }



}
