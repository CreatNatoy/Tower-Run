using UnityEngine;

public class Checker : MonoBehaviour
{
    [SerializeField] private PlayerTowerSpawn _playerTower;

    private void Update()
    {
        Vector3 position = new Vector3(_playerTower.transform.position.x, transform.position.y, _playerTower.transform.position.z);
        transform.position = position; 
    }

    public Vector3 GetPosition()
    {
        return transform.position; 
    }
}
