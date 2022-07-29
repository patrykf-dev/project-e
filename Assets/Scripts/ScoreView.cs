using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _player0Score;

        [SerializeField]
        private TextMeshProUGUI _player1Score;

        private void Start()
        {
            Registry.scoreManager.player0Score.ValueChanged += HandlePlayer0ScoreChanged;
            Registry.scoreManager.player1Score.ValueChanged += HandlePlayer1ScoreChanged;
            HandlePlayer0ScoreChanged(0, 0);
            HandlePlayer1ScoreChanged(0, 0);
        }

        private void HandlePlayer0ScoreChanged(int lastvalue, int newvalue)
        {
            RefreshPlayerScore(0, newvalue);
        }

        private void RefreshPlayerScore(int playerId, int newvalue)
        {
            var textToUpdate = playerId == 0 ? _player0Score : _player1Score;
            textToUpdate.text = $"Player {playerId} score: {newvalue}";
        }

        private void HandlePlayer1ScoreChanged(int lastvalue, int newvalue)
        {
            RefreshPlayerScore(1, newvalue);
        }

        private void OnDestroy()
        {
            Registry.scoreManager.player0Score.ValueChanged -= HandlePlayer0ScoreChanged;
            Registry.scoreManager.player1Score.ValueChanged -= HandlePlayer1ScoreChanged;
        }
    }
}
