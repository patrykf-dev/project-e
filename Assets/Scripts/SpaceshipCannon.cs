using Elympics;

public class SpaceshipCannon : ElympicsMonoBehaviour, IUpdatable
{
    private const string BULLET_PREFAB_PATH = "SynchronizedPrefabs/Bullet";
    private readonly ElympicsFloat _shootTimer = new ElympicsFloat();

    public void ProcessInput(bool shootInput, int playerIndex)
    {
        if (shootInput && _shootTimer >= 0.3f)
        {
            var spaceshipTransform = transform;
            var position = spaceshipTransform.position + .7f * spaceshipTransform.up;
            var createdObject = ElympicsInstantiate(BULLET_PREFAB_PATH, ElympicsPlayer.FromIndex(playerIndex));
            var bullet = createdObject.GetComponent<Bullet>();
            bullet.transform.position = position;
            bullet.transform.rotation = spaceshipTransform.rotation;
            var settings = new BulletSettings(2f, 4f, (int) PredictableFor);
            bullet.Initialize(settings);
            _shootTimer.Value = 0f;
        }
    }

    public void ElympicsUpdate()
    {
        if (_shootTimer < 0.3f)
        {
            _shootTimer.Value += Elympics.TickDuration;
        }
    }
}
