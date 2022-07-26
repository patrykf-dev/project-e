using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    [SerializeField]
    private float _accelerationForce = 0.8f;
    [SerializeField]
    private float _rotationForce = 10f;
    [SerializeField]
    private float _maxVelocity = 2.5f;
    [SerializeField]
    private float _maxAngularVelocity = 70f;

    private Rigidbody2D _rigidbody;
    private float _rotationInput;
    private float _accelerationInput;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rotationInput = Input.GetAxis("Horizontal");
        _accelerationInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        _rigidbody.AddRelativeForce(Vector2.up * (_accelerationInput * _accelerationForce));
        _rigidbody.AddTorque(-_rotationInput * _rotationForce);

        _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, _maxVelocity);
        _rigidbody.angularVelocity = Mathf.Clamp(_rigidbody.angularVelocity, -_maxAngularVelocity, _maxAngularVelocity);
    }
}
