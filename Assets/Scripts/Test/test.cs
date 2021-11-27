using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] private GameObject _test;

    private void Start()
    {
        GameObject test = Instantiate(_test, transform.position, Quaternion.identity); 
    }

}
