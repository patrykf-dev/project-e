public class BulletSettings
{
    public readonly float timeToLive;
    public readonly float speed;
    public readonly int ownerId;

    public BulletSettings(float timeToLive, float speed, int ownerId)
    {
        this.timeToLive = timeToLive;
        this.speed = speed;
        this.ownerId = ownerId;
    }
}
