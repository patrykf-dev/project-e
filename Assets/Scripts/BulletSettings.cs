public class BulletSettings
{
    public readonly float timeToLive;
    public readonly float speed;
    public SpaceshipCannon owner;

    public BulletSettings(float timeToLive, float speed, SpaceshipCannon owner)
    {
        this.timeToLive = timeToLive;
        this.speed = speed;
        this.owner = owner;
    }
}
