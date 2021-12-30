using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Jumper))]
public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private Text _textCoins;
    [SerializeField] private SoundEffects _soundEffects;
    [SerializeField] private Transform _distanceChecker;
    [SerializeField] private float _fixationMaxDistance;
    [SerializeField] private BoxCollider _checkCollider;
    [SerializeField] private Checker _checker;

    private GameBehavior _gameBehavior;
    private Jumper _heightPlayerTower;
    private Rigidbody _rigidbody;

    private int _counterCoins;
    private bool _oneCollisionObstacle = false;

    public int CounterCoiuns => _counterCoins; 

    public event UnityAction<int> HumanDepriveCamera;
    public event UnityAction<int> HumanAddedCamera;

    private void Start()
    {
        _gameBehavior = GetComponent<GameBehavior>();
        _heightPlayerTower = GetComponent<Jumper>();
        _rigidbody = GetComponent<Rigidbody>(); 

    }

    public void AddCoin(Coin coin)
    {
        coin.gameObject.SetActive(false);
        _counterCoins++;
        _textCoins.text = _counterCoins.ToString("D3");
        _soundEffects.AddCoinSound();
    }


    public void CollisionObstacle(Obstacle obstacle, List<Human> _humans)
    {
        if (!_oneCollisionObstacle)
        {
            int sizeObstacle = obstacle.SizeObstacle;
            if (JumpedObstacle())
            {
                sizeObstacle--;
            }
            if (sizeObstacle < _humans.Count)
            {
                DeleteHumans(sizeObstacle, _humans);
            }
            else
            {
                _gameBehavior.GameOver();
            }
            Invoke("UpdateOneObstacle", 1);
        }
    }

    private void UpdateOneObstacle()
    {
        _oneCollisionObstacle = false;
    }

    private void DeleteHumans(int sizeObstacle, List<Human> _humans)
    {
        _oneCollisionObstacle = true;
        _humans[0].StopRun();
        for (int i = 0; i < sizeObstacle; i++)
        {
            Destroy(_humans[i].gameObject);
        }
        _humans.RemoveRange(0, sizeObstacle);
        _humans[0].Run();
        HumanDepriveCamera?.Invoke(sizeObstacle);
        _soundEffects.DeleteHuman();
    }

    private bool JumpedObstacle()
    {
        float heightObstacle = 1f; 
        if (_heightPlayerTower.HeightPlayerTower < transform.position.y - heightObstacle)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CollisionHumans(Tower collisionTower, List<Human> _humans)
    {
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
                    InsertHuman(insetHuman, _humans);
                    DisplaceCheckers();
                }
                HumanAddedCamera?.Invoke(_humans.Count);
                _humans[0].Run();
            }
            else
                _rigidbody.velocity = Vector3.zero;
     
        }
        if (collisionTower != null)
            collisionTower.Break();
    }

    private void InsertHuman(Human collectedHumans, List<Human> _humans)
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
