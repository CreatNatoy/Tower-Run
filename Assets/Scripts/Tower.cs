using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tower : MonoBehaviour
{
    [SerializeField] private Vector2Int _humanInTowerRange;  
    [SerializeField] private Human[] _humansTemplates;
    [SerializeField] private float _bounceForce;
    [SerializeField] private float _bounceRadius;
    [SerializeField] private TMP_Text _sizeHumons;

    private List<Human> _humanInTower;

    private void Start()
    {
        _humanInTower = new List<Human>();
        int humanInTowerCount = Random.Range(_humanInTowerRange.x, _humanInTowerRange.y);
        SpawnHumans(humanInTowerCount);
        _sizeHumons.text = GetSizeHumans().ToString(); 
    }

    private void SpawnHumans(int humanCount)
    {
        Vector3 spawnPoint = transform.position;

        for(int i =0; i < humanCount; i++)
        {
            Human spawnedHuman = _humansTemplates[Random.Range(0, _humansTemplates.Length)];
           // spawnedHuman.transform.rotation = Quaternion.Euler(0, 90, 0); 

            _humanInTower.Add(Instantiate(spawnedHuman, spawnPoint, Quaternion.Euler(0, 90, 0), transform));

            _humanInTower[i].transform.localPosition = new Vector3(0, _humanInTower[i].transform.localPosition.y, 0);

            spawnPoint = _humanInTower[i].FixationPoint.position; 
        }

    }


    public List<Human> CollectHuman(Transform distanceChecker, float fixationMaxDistance)
    {
        for(int i=0; i< _humanInTower.Count; i++)
        {
            float distanceBetweenPoints = CheckDistanceY(distanceChecker, _humanInTower[i].FixationPoint.transform);
            if (distanceBetweenPoints < fixationMaxDistance)
            {
                List<Human> collectedHumans = _humanInTower.GetRange(0,i+1);
                _humanInTower.RemoveRange(0, i + 1);
                return collectedHumans;
            }
        }
        return null; 
    }

    private float CheckDistanceY(Transform distanceChecker, Transform humanFixationPoint)
    {
        Vector3 distanceCheckerY = new Vector3(0, distanceChecker.position.y, 0);
        Vector3 humanFixationPointY = new Vector3(0, humanFixationPoint.position.y, 0);
        return Vector3.Distance(distanceCheckerY, humanFixationPointY); 
    }

    public void Break() // effect destroy
    {
       // Destroy(gameObject); 
       Human[] humans = GetComponentsInChildren<Human>();

        foreach(var human in humans)
        {
                    human.Bounce(_bounceForce, transform.position, _bounceRadius);
        }
    }

    public int GetSizeHumans()
    {
        return _humanInTower.Count; 
    }
}


