using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(GameBehavior))]
[RequireComponent(typeof(PlayerBehavior))]
public class PlayerTower : MonoBehaviour
{
    [SerializeField] private Human _startHuman; 

    private GameBehavior _gameBehavior;
    private PlayerBehavior _playerBehavior;

    private List<Human> _humans;

    private void Start()
    {
        _gameBehavior = GetComponent<GameBehavior>();
        _playerBehavior = GetComponent<PlayerBehavior>(); 

        _humans = new List<Human>();
        Vector3 spawnPoint = transform.position;
        _humans.Add(Instantiate(_startHuman, spawnPoint, Quaternion.identity, transform));
        _humans[0].Run();
    }


    private void OnCollisionEnter(Collision collision)
      {
          if(collision.gameObject.TryGetComponent(out Human human))
        {
            Tower collisionTower = human.GetComponentInParent<Tower>();
            _playerBehavior.CollisionHumans(collisionTower, _humans);
        }
          if(collision.gameObject.tag == "Obstacle")
        {
            Obstacle obstacle = collision.gameObject.GetComponentInParent<Obstacle>();
            _playerBehavior.CollisionObstacle(obstacle, _humans); 
        }
          if(collision.gameObject.TryGetComponent(out Finish finish))
        {
            _gameBehavior.FinishGame(); 
        }
          if(collision.gameObject.TryGetComponent(out Coin coin))
        {
            _playerBehavior.AddCoin(coin); 
        }
    }
}
