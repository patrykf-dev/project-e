using DefaultNamespace;
using Elympics;

public class SpaceshipHealth : ElympicsMonoBehaviour
{
    public void HandleHit(int attackerId)
    {
        Registry.scoreManager.HandleSpaceshipDamaged(attackerId);
    }
}
