using Elympics;
using UnityEngine;

namespace DefaultNamespace
{
    public class InputController : ElympicsMonoBehaviour, IInputHandler, IUpdatable, IInitializable
    {
        [SerializeField]
        private int _playerId;
        [SerializeField]
        private SpaceshipMovement _movement;
        [SerializeField]
        private SpaceshipCannon _cannon;

        private InputProvider _inputProvider;

        public void Initialize()
        {
            _inputProvider = GetComponent<InputProvider>();
        }

        public void OnInputForClient(IInputWriter inputSerializer)
        {
            if (Elympics.Player == ElympicsPlayer.FromIndex(_playerId))
            {
                SerializeInput(inputSerializer);
            }
        }

        private void SerializeInput(IInputWriter inputWriter)
        {
            inputWriter.Write(_inputProvider.RotationInput);
            inputWriter.Write(_inputProvider.AccelerationInput);
            inputWriter.Write(_inputProvider.ShootInput);
            inputWriter.Write(_inputProvider.ShowScoreboardInput);
        }

        public void OnInputForBot(IInputWriter inputSerializer)
        {
            // TODO
        }

        public void ElympicsUpdate()
        {
            var rotationInput = 0.0f;
            var accelerationInput = 0.0f;
            var shootInput = false;
            var showScoreboardInput = false;

            if (ElympicsBehaviour.TryGetInput(ElympicsPlayer.FromIndex(_playerId), out var inputDeserializer))
            {
                inputDeserializer.Read(out rotationInput);
                inputDeserializer.Read(out accelerationInput);
                inputDeserializer.Read(out shootInput);
                inputDeserializer.Read(out showScoreboardInput);
            }

            _movement.ProcessMovement(rotationInput, accelerationInput);
            _cannon.ProcessInput(shootInput, _playerId);
        }
    }
}
