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
    [SerializeField] private Menu _menuCanvas;
    [SerializeField] private GameObject _panelGameOver;
    [SerializeField] private GameObject _panelFinish; 

    private Jumper _heightPlayerTower; 

    private List<Human> _humans;
    private bool _oneObstacle = false; 

    public event UnityAction<int> HumanAdded; 

    private void Start()
    {
        _heightPlayerTower = GetComponent<Jumper>(); 
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
                        DisplaceCheckers();
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
          if(collision.gameObject.TryGetComponent(out Finish finish))
        {
            FinishGame(); 
        }
    }

    private void CollisionObstacle(Obstacle obstacle)
    {
        int sizeObstacle = obstacle.SizeObstacle;
        if (JumpedObstacle() && !_oneObstacle)
        {
            sizeObstacle--;
        }
        if (sizeObstacle < _humans.Count && !_oneObstacle)
        {
            DeleteHumans(sizeObstacle); 
        }
        else if(!_oneObstacle)
        {
            GameOver(); 
        }
        Invoke("UpdateOneObstacle", 1); 
    }

    private void UpdateOneObstacle()
    {
        _oneObstacle = false; 
    }

    private void GameOver()
    {
        _panelGameOver.SetActive(true);
        ActivePanel(_panelGameOver); 
    }

    private void FinishGame()
    {
        _panelFinish.SetActive(true);
        ActivePanel(_panelFinish);
    }

    private void  ActivePanel(GameObject panel)
    {
        _menuCanvas.OnPanel(panel);
        _menuCanvas.TimeGame(0);
    }

    private bool JumpedObstacle()
    {
        if (_heightPlayerTower.HeightPlayerTower < transform.position.y - 1f)
        {
            return true;
        }
        else
        {
            return false;
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

    public void DisplaceCheckers()
    {
        _distanceChecker.position = _checker.GetPosition();
        _checkCollider.center = _distanceChecker.localPosition; 
    }
}
