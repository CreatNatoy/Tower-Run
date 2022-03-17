using UnityEngine;

[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(PlayerBehavior))]
[RequireComponent(typeof(PlayerTowerSpawn))]
public class PlayerTowerCollison : MonoBehaviour
{
    [SerializeField] private CounterCoin _counterCoin;
    [SerializeField] private GameBehavior _gameBehavior;
    private Jumper _jump;
    private PlayerBehavior _playerBehavior;
    private PlayerTowerSpawn _playerTower;

    private void Start()
    {
        _jump = GetComponent<Jumper>();
        _playerBehavior = GetComponent<PlayerBehavior>();
        _playerTower = GetComponent<PlayerTowerSpawn>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Road rouad))
        {
            _jump.LandingRoad(); 
        }

        Tower tower = collision.gameObject.GetComponentInParent<Tower>();
        if (tower)
        {
            _playerBehavior.CollisionHumans(tower, _playerTower.Humans);
        }

        Obstacle obstacle = collision.gameObject.GetComponentInParent<Obstacle>();
        if (obstacle)
        {
            _playerBehavior.CollisionObstacle(obstacle, _playerTower.Humans);
        }

        if (collision.gameObject.TryGetComponent(out Finish finish))
        {
            _gameBehavior.FinishGame(_playerTower.Humans.Count);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PointJump pointJump))
        {
            Tower ColliderTower = pointJump.GetComponentInParent<Tower>();
            _jump.AddJumpForse(ColliderTower.GetSizeHumans());
            pointJump.ChangeColor();
        }

        if (other.gameObject.TryGetComponent(out Coin coin))
        {
            _counterCoin.AddCoin(coin);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PointJump pointJump))
        {
            _jump.StartJumpForse(); 
            pointJump.StartColor();
        }
    }
}
