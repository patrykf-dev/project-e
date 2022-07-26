using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class AsteroidSpawner : MonoBehaviour
    {
        [SerializeField]
        private Asteroid _asteroidPrefab;
        [SerializeField]
        private SpriteRenderer _backgroundSprite;

        private const float LEVEL_BOUNDING = 0.8f;
        private const int ASTEROIDS_COUNT_CAP = 6;

        private readonly List<Asteroid> _spawnedAsteroids = new List<Asteroid>();
        private float _timer;

        private void Update()
        {
            if (_timer >= 3f)
            {
                TrySpawningAsteroid();
                _timer = 0f;
            }
            else
            {
                _timer += Time.deltaTime;
            }
        }

        private void TrySpawningAsteroid()
        {
            if (_spawnedAsteroids.Count < ASTEROIDS_COUNT_CAP)
            {
                SpawnAsteroid();
            }
        }

        private void SpawnAsteroid()
        {
            var levelBounds = _backgroundSprite.bounds;
            var xBound = levelBounds.center.x + LEVEL_BOUNDING * levelBounds.extents.x;
            var yBound = levelBounds.center.y + LEVEL_BOUNDING * levelBounds.extents.y;
            var randomX = Random.Range(-xBound, xBound);
            var randomY = Random.Range(-yBound, yBound);
            var asteroidPosition = new Vector3(randomX, randomY, 0f);
            var asteroid = Instantiate(_asteroidPrefab, asteroidPosition, Quaternion.identity);
            _spawnedAsteroids.Add(asteroid);
            asteroid.OnShotDown += RemoveAsteroid;
        }

        private void RemoveAsteroid(Asteroid destroyedAsteroid)
        {
            destroyedAsteroid.OnShotDown -= RemoveAsteroid;
            _spawnedAsteroids.Remove(destroyedAsteroid);
        }
    }
}
