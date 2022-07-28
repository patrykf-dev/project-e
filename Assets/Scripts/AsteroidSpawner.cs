using System.Collections.Generic;
using Elympics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class AsteroidSpawner : ElympicsMonoBehaviour, IUpdatable
    {
        [SerializeField]
        private SpriteRenderer _backgroundSprite;

        private const float LEVEL_BOUNDING = 0.8f;
        private const int ASTEROIDS_COUNT_CAP = 6;

        private readonly List<Asteroid> _spawnedAsteroids = new List<Asteroid>();
        private readonly ElympicsFloat _spawnTimer = new ElympicsFloat();

        private const string ASTEROID_PREFAB_PATH = "SynchronizedPrefabs/Asteroid";

        public void ElympicsUpdate()
        {
            if (Elympics.IsServer)
            {
                if (_spawnTimer >= 3f)
                {
                    TrySpawningAsteroid();
                    _spawnTimer.Value = 0f;
                }
                else
                {
                    _spawnTimer.Value += Elympics.TickDuration;
                }
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

            var asteroidObject = ElympicsInstantiate(ASTEROID_PREFAB_PATH, ElympicsPlayer.World);
            asteroidObject.transform.position = asteroidPosition;
            var asteroid = asteroidObject.GetComponent<Asteroid>();
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
