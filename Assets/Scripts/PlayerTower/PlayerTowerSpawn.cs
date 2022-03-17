using System.Collections.Generic;
using UnityEngine;

public class PlayerTowerSpawn : MonoBehaviour
{
    [SerializeField] private Human[] _startHumans;
    [SerializeField] private Save _savePlayerSkin;

    private Human _startHuman;
    private List<Human> _humans;

    public List<Human> Humans => _humans; 

    private void Start()
    {
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
}
