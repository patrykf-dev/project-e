using UnityEngine;

public class SpaceshipCannon : MonoBehaviour
{
    [SerializeField]
    private Bullet _bulletPrefab;

    private float _timer;

    private void Update()
    {
        if (_timer >= 0.3f)
        {
            HandleShootUpdate();
        }
        else
        {
            _timer += Time.deltaTime;
        }
    }

    private void HandleShootUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var spaceshipTransform = transform;
            var position = spaceshipTransform.position + 0.5f * spaceshipTransform.up;
            var bullet = Instantiate(_bulletPrefab, position, spaceshipTransform.rotation);

            var settings = new BulletSettings(2f, 4f);
            bullet.Initialize(settings);
            _timer = 0f;
        }
    }
}