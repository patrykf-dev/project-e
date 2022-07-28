using System;
using Elympics;
using UnityEngine;

public class Asteroid : ElympicsMonoBehaviour
{
    public event Action<Asteroid> OnShotDown; 
    
    [SerializeField]
    private int _shotsToDestroy;

    [SerializeField]
    private ParticleSystem _damageVfx;

    private int _shotsLeft;

    private void Awake()
    {
        _shotsLeft = _shotsToDestroy;
    }

    public void HandleHit(SpaceshipCannon owner)
    {
        _shotsLeft--;
        _damageVfx.Play();

        if (_shotsLeft <= 0)
        {
            OnShotDown?.Invoke(this);
            ElympicsDestroy(gameObject);
        }
    }
}
