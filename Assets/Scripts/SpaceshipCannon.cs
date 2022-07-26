using Elympics;
using UnityEngine;

public class SpaceshipCannon : ElympicsMonoBehaviour
{
    private float _timer;

    private void Update()
    {
        if (_timer < 0.3f)
        {
            _timer += Time.deltaTime;
        }
    }

    public void ProcessInput(bool shootInput)
    {
        if (shootInput && _timer >= 0.3f)
        {
            var spaceshipTransform = transform;
            var position = spaceshipTransform.position + 0.5f * spaceshipTransform.up;
            var bullet = ElympicsInstantiate("SynchronizedPrefabs/Bullet", ElympicsPlayer.All).GetComponent<Bullet>();
            bullet.transform.position = position;
            bullet.transform.rotation = spaceshipTransform.rotation;
            var settings = new BulletSettings(2f, 4f, this);
            bullet.Initialize(settings);
            _timer = 0f;
        }
    }
}
