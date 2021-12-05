using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTower : MonoBehaviour
{
    [SerializeField] private Human _startHuman; 
    [SerializeField] private Transform _distanceChecker;
    [SerializeField] private float _fixationMaxDistance;
    [SerializeField] private BoxCollider _checkCollider;
    [SerializeField] private Checker _checker;

    private List<Human> _humans;
    private bool _oneObstacle = false; 

    public event UnityAction<int> HumanAdded; 

    private void Start()
    {
        _humans = new List<Human>();
        Vector3 spawnPoint = transform.position;
        _humans.Add(Instantiate(_startHuman, spawnPoint, Quaternion.identity, transform));
        _humans[0].Run();
        HumanAdded?.Invoke(_humans.Count);
    }


    private void OnCollisionEnter(Collision collision)
      {
          if(collision.gameObject.TryGetComponent(out Human human))
        {
            Tower collisionTower = human.GetComponentInParent<Tower>();
            if (collisionTower != null)
            {
                List<Human> collectedHumans = collisionTower.CollectHuman(_distanceChecker, _fixationMaxDistance);
                if (collectedHumans != null)
                {
                    _humans[0].StopRun();
                    for (int i = collectedHumans.Count - 1; i >= 0; i--)
                    {
                        Human insetHuman = collectedHumans[i];
                        insetHuman.DeleteRigibody(); 
                        InsertHuman(insetHuman);
                        DisplaceCheckers(insetHuman);
                    }
                    HumanAdded?.Invoke(_humans.Count);
                    _humans[0].Run();
                }
            }
            if(collisionTower != null) 
            collisionTower.Break();
        }
          if(collision.gameObject.tag == "Obstacle")
        {
            Obstacle obstacle = collision.gameObject.GetComponentInParent<Obstacle>();
            CollisionObstacle(obstacle); 
        }
    }

    private void CollisionObstacle(Obstacle obstacle)
    {
        int sizeObstacle = obstacle.SizeObstacle;
        float jumpPlayer = 1f; 
        if (transform.position.y > jumpPlayer && !_oneObstacle)
        {
            sizeObstacle--;
        }
        if (sizeObstacle < _humans.Count && !_oneObstacle)
        {
            DeleteHumans(sizeObstacle); 
        }
        else if (!_oneObstacle)
        {
            Debug.Log("You die");
        }
    }

    private void DeleteHumans(int sizeObstacle)
    {
        _oneObstacle = true;
        _humans[0].StopRun();
        for (int i = 0; i < sizeObstacle; i++)
        {
            Destroy(_humans[i].gameObject);
        }
        _humans.RemoveRange(0, sizeObstacle);
        _humans[0].Run();
    }

    private void InsertHuman(Human collectedHumans)
    {
        _humans.Insert(0, collectedHumans);
        SetHumanPosition(collectedHumans);
    }

    private void SetHumanPosition(Human human)
    {
        human.transform.parent = transform;
        human.transform.localPosition = new Vector3(0, human.transform.localPosition.y, 0);
        human.transform.localRotation = Quaternion.identity; 
    }

    private void DisplaceCheckers(Human human)
    {
        //  float displaceScale = 1f;
        //  float displaceScale = 1.5f; 
        //   float displaceScale = 1.35f;
        /*  Vector3 distanceCheckerNewPosition = _distanceChecker.position;
          distanceCheckerNewPosition.y -= human.transform.localScale.y * displaceScale;
          _distanceChecker.position = distanceCheckerNewPosition;
          _checkCollider.center = _distanceChecker.localPosition; */

        _distanceChecker.position = _checker.GetPosition();
        _checkCollider.center = _distanceChecker.localPosition; 

    }
}
