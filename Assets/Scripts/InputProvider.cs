using UnityEngine;

namespace DefaultNamespace
{
    public class InputProvider : MonoBehaviour
    {
        public float RotationInput { get; private set; }
        public float AccelerationInput { get; private set; }
        public bool ShootInput { get; private set; }
        public bool ShowScoreboardInput { get; private set; }

        private void Update()
        {
            RotationInput = Input.GetAxis("Horizontal");
            AccelerationInput = Input.GetAxis("Vertical");
            ShootInput = Input.GetKey(KeyCode.Space);
            ShowScoreboardInput = Input.GetKey(KeyCode.Tab);
        }
    }
}
