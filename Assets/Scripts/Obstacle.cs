using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int _sizeObstacle = 1;
    [SerializeField] private GameObject _obstacle; 

    public int SizeObstacle => _sizeObstacle;

    private void Start()
    {
        SpawnObstacle(_sizeObstacle);    
    }

    private void SpawnObstacle(int obstacleCount)
    {
        Vector3 spawnPoint = transform.position; 

        for(int i =0; i < obstacleCount; i++)
        {
           GameObject obstacle = Instantiate(_obstacle, spawnPoint, Quaternion.Euler(90,0,0), transform);
           spawnPoint.y += obstacle.GetComponent<BoxCollider>().size.y; 
        }
    }
}
