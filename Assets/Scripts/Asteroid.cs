using System;
using DefaultNamespace;
using Elympics;
using UnityEngine;

public class Asteroid : ElympicsMonoBehaviour, IObservable
{
    public event Action<Asteroid> OnShotDown;

    [SerializeField]
    private int _shotsToDestroy;

    [SerializeField]
    private ParticleSystem _damageVfx;

    private readonly ElympicsInt _shotsLeft = new ElympicsInt();

    private void Awake()
    {
        _shotsLeft.Value = _shotsToDestroy;
    }

    public void HandleHit(int ownerId)
    {
        _shotsLeft.Value--;
        _damageVfx.Play();

        Debug.Log($"Handling hit from {ownerId}, shots left: {_shotsLeft}");
        
        if (_shotsLeft <= 0)
        {
            Registry.scoreManager.HandleAsteroidDestroyed(ownerId);
            OnShotDown?.Invoke(this);
            ElympicsDestroy(gameObject);
        }
    }
}
