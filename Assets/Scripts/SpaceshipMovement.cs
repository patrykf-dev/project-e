using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    [SerializeField]
    private float _accelerationForce = 0.8f;
    [SerializeField]
    private float _rotationForce = 10f;
    [SerializeField]
    private float _maxVelocity = 2.5f;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var rotation = Input.GetAxis("Horizontal");
        var acceleration = Input.GetAxis("Vertical");
        _rigidbody.AddRelativeForce(Vector2.up * (acceleration * _accelerationForce));
        _rigidbody.AddTorque(-rotation * _rotationForce);
        _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, _maxVelocity);
    }
}
