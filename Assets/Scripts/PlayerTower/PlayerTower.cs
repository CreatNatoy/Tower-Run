using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameBehavior))]
[RequireComponent(typeof(PlayerBehavior))]
public class PlayerTower : MonoBehaviour
{
    [SerializeField] private Human[] _startHumans;
    [SerializeField] private Save _savePlayerSkin;
    private Human _startHuman;

    private GameBehavior _gameBehavior;
    private PlayerBehavior _playerBehavior;

    private List<Human> _humans;

    private void Start()
    {
        _gameBehavior = GetComponent<GameBehavior>();
        _playerBehavior = GetComponent<PlayerBehavior>();
        CreateStartPlayer();
    }

    private void CreateStartPlayer()
    {
        _humans = new List<Human>();
        Vector3 spawnPoint = transform.position;
        _startHuman = _startHumans[_savePlayerSkin.GetKeyPlayer()];
        _humans.Add(Instantiate(_startHuman, spawnPoint, Quaternion.identity, transform));
        _humans[0].Run();
    }


    private void OnCollisionEnter(Collision collision)
    {
        Tower tower = collision.gameObject.GetComponentInParent<Tower>();
        if (tower)
        {
            _playerBehavior.CollisionHumans(tower, _humans);
        }

        Obstacle obstacle = collision.gameObject.GetComponentInParent<Obstacle>();
        if (obstacle)
        {
            _playerBehavior.CollisionObstacle(obstacle, _humans);
        }

        if (collision.gameObject.TryGetComponent(out Finish finish))
        {
            _gameBehavior.FinishGame(_humans.Count);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Coin coin))
        {
            _playerBehavior.AddCoin(coin);
        }
    }
}
