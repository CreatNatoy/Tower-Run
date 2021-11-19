using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] private PathCreator _pathCreator;
    [SerializeField] private Tower _torwerTemplate;
    [SerializeField] private int _humanTowerCount;

    private void Start()
    {
        GenerateLevel(); 
    }

    private void GenerateLevel()
    {
        float roadLength = _pathCreator.path.length;
        float distanceBetweenTower = roadLength / _humanTowerCount;

        float distanceTravelled = 0;
        Vector3 spawnPoint; 

        for(int i=0; i < _humanTowerCount; i++)
        {
            distanceTravelled += distanceBetweenTower;
            spawnPoint = _pathCreator.path.GetPointAtDistance(distanceTravelled, EndOfPathInstruction.Stop);

            Instantiate(_torwerTemplate, spawnPoint, Quaternion.identity);
        }
    }

}
