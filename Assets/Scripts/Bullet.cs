using System;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private BulletSettings _settings;
    private float _timer;
    private Transform _transform;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
    }

    private void Awake()
    {
        _transform = transform;
    }

    public void Initialize(BulletSettings settings)
    {
        _settings = settings;
    }

    private void Update()
    {
        HandleTtl();
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        var newPosition = _transform.position + _transform.up * (_settings.speed * Time.deltaTime);
        _transform.position = newPosition;
    }

    private void HandleTtl()
    {
        if (_timer > _settings.timeToLive)
        {
            Destroy(gameObject);
        }

        _timer += Time.deltaTime;
    }
}
