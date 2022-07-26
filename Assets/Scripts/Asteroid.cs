using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private int _shotsToDestroy;

    private int _shotsLeft;

    private void Awake()
    {
        _shotsLeft = _shotsToDestroy;
    }

    public void HandleHit(SpaceshipCannon owner)
    {
        _shotsLeft--;

        if (_shotsLeft <= 0)
        {
            Destroy(gameObject);
        }
    }
}
