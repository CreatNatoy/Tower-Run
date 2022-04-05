using UnityEngine;
using UnityEngine.UI;

public class IndicatorPlayerToFinish : MonoBehaviour
{
    [SerializeField] private Transform _playerTowerTransform;
    [SerializeField] private Transform _finishTransform;
    [SerializeField] private Slider _indicatorSlider;

    private float _maxDistance;
    private float _currentDistance; 

    private void Start()
    {
        _maxDistance = Vector2.Distance(_playerTowerTransform.position, _finishTransform.position);

        _indicatorSlider.maxValue = _maxDistance;
        _indicatorSlider.value = 0;
    }

    private void Update()
    {
        _currentDistance = Vector2.Distance(_playerTowerTransform.position, _finishTransform.position);
        _indicatorSlider.value = (_maxDistance - _currentDistance);
    }
}
