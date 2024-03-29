using Elympics;
using UnityEngine;

public class Bullet : ElympicsMonoBehaviour, IUpdatable
{
    private readonly ElympicsFloat _timeAlive = new ElympicsFloat();
    private BulletSettings _settings;
    private Transform _transform;
    private bool _scheduleDestroy;
    private bool _isInitialized;

    private void Awake()
    {
        _transform = transform;
    }

    public void Initialize(BulletSettings settings)
    {
        _settings = settings;
        _isInitialized = true;
    }

    public void ElympicsUpdate()
    {
        if (IsPredictableForMe && _isInitialized)
        {
            _timeAlive.Value += Elympics.TickDuration;

            if (_timeAlive >= _settings.timeToLive)
            {
                ElympicsDestroy(gameObject);
            }

            if (_scheduleDestroy)
            {
                ElympicsDestroy(gameObject);
                _scheduleDestroy = false;
            }

            UpdatePosition();
        }
    }

    private void UpdatePosition()
    {
        var newPosition = _transform.position + _transform.up * (_settings.speed * Time.deltaTime);
        _transform.position = newPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var asteroidHit = other.gameObject.layer == LayerMask.NameToLayer("Asteroid");
        var spaceshipHit = other.gameObject.layer == LayerMask.NameToLayer("Spaceship");

        if (IsPredictableForMe)
        {
            if (asteroidHit)
            {
                HandleAsteroidHit(other);
            }
            else if (spaceshipHit)
            {
                HandleSpaceshipHit(other);
            }
        }
    }

    private void HandleSpaceshipHit(Collider2D other)
    {
        var spaceshipHealth = other.gameObject.GetComponent<SpaceshipHealth>();

        if (spaceshipHealth != null)
        {
            spaceshipHealth.HandleHit(_settings.ownerId);
            _scheduleDestroy = true;
        }
    }

    private void HandleAsteroidHit(Collider2D other)
    {
        var asteroidObject = other.gameObject.GetComponent<Asteroid>();

        if (asteroidObject != null)
        {
            asteroidObject.HandleHit(_settings.ownerId);
            _scheduleDestroy = true;
        }
    }
}
