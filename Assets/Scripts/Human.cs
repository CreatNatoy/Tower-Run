using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Human : MonoBehaviour
{
    [SerializeField] private Transform _fixationPoint;

    private Animator _animator;


    public Transform FixationPoint => _fixationPoint;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Run()
    {
        _animator.SetBool("isRunning", true); 
    }

    public void StopRun()
    {
        _animator.SetBool("isRunning", false); 
    }

    public void Bounce(float force, Vector3 center, float radius)
    {
        if(TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.isKinematic = false;
            rigidbody.AddExplosionForce(force, center - new Vector3(-1,0,0), radius); 
        }
    }

    public void DeleteRigibody()
    {
        if (TryGetComponent(out Rigidbody rigidbody))
                Destroy(rigidbody); 
    }
}
