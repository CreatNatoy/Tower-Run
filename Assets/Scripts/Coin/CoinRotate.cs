using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    [SerializeField] private float _speedRotation; 

    private void Update()
    {
        transform.Rotate(new Vector3(0f, _speedRotation, 0f) * Time.deltaTime);
    }
}
