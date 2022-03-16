using UnityEngine;

[RequireComponent(typeof(PlayerBehavior))]
[RequireComponent(typeof(Rigidbody))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private SoundEffects _soundEffects;

    private float _startJumpForce;
    private bool _isGrounded;
    private Rigidbody _rigidbody;
    private PlayerBehavior _updateCheker;
    private float _heightPlayerTower;

    public float HeightPlayerTower => _heightPlayerTower;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _updateCheker = GetComponent<PlayerBehavior>();
        _startJumpForce = _jumpForce;
        _heightPlayerTower = transform.position.y;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isGrounded)
        {
            _isGrounded = false;
            _rigidbody.AddForce(Vector3.up * _jumpForce);
            _soundEffects.JumpUpSound();

            if (_startJumpForce != _jumpForce)
                _soundEffects.JumpStrongSound();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Road rouad))
        {
            _heightPlayerTower = transform.position.y;
            _updateCheker.DisplaceCheckers();
            _soundEffects.JumpDownSound();
            _isGrounded = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PointJump pointJump))
        {
            Tower ColliderTower = pointJump.GetComponentInParent<Tower>();
            ChangeJumpForse(ColliderTower.GetSizeHumans());
            pointJump.ChangeColor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PointJump pointJump))
        {
            _jumpForce = _startJumpForce;
            pointJump.StartColor();
        }
    }

    private void ChangeJumpForse(int jumpForse)
    {
        _jumpForce = _jumpForce + 0.1f + (jumpForse - 1) * 25f;
    }
}
