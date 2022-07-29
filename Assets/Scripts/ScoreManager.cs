using Elympics;
using UnityEngine;

namespace DefaultNamespace
{
    public class ScoreManager : MonoBehaviour, IObservable
    {
        public ElympicsInt player0Score = new ElympicsInt();
        public ElympicsInt player1Score = new ElympicsInt();

        private void Awake()
        {
            Registry.scoreManager = this;
        }

        public void HandleAsteroidDestroyed(int ownerId)
        {
            IncrementScore(ownerId);
        }

        public void HandleSpaceshipDamaged(int attackerId)
        {
            IncrementScore(attackerId);
        }

        private void IncrementScore(int attackerId)
        {
            if (attackerId == 0)
            {
                player0Score.Value++;
            }
            else
            {
                player1Score.Value++;
            }
        }
    }
}
