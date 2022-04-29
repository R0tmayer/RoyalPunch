using Core.CustomInput;
using Core.StateMachine.Hero.States;
using UnityEngine;

namespace Core.StateMachine.Hero
{
    public class HeroStateMachine : MonoBehaviour
    {
        [field: SerializeField] public HeroAnimationStates Animations { get; private set; }
        [field: SerializeField] public Transform Hero { get; private set; }
        [field: SerializeField] public CharacterController CharacterController { get; private set; }
        [field: SerializeField] public InputJoystickReceiver Input { get; private set; }
        public bool IsMagnetism { get; set; }


        private HeroBaseState _currentState;
        private HeroMoveAndPunchState _moveAndPunchState = new HeroMoveAndPunchState();
        private HeroFallState _fallState = new HeroFallState();

        #region Execution

        private void Start()
        {
            _currentState = _moveAndPunchState;
            _currentState.EnterState(this);
        }

        private void Update()
        {
            _currentState.UpdateState(this);
        }

        private void OnCollisionEnter(Collision other)
        {
            _currentState.OnCollisionEnter(this, other);
        }

        private void OnTriggerEnter(Collider other)
        {
            _currentState.OnTriggerEnter(this, other);
        }

        private void OnTriggerExit(Collider other)
        {
            _currentState.OnTriggerExit(this, other);
        }

        #endregion

        #region Switch State Presets

        public void SwitchState(HeroBaseState state)
        {
            _currentState.ExitState(this);
            _currentState = state;
            _currentState.EnterState(this);
        }

        #endregion
    }
}