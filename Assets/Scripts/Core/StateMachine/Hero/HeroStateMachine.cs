using System;
using Core.CustomInput;
using Core.StateMachine.Boss;
using Core.StateMachine.Hero.States;
using Core.UI;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Core.StateMachine.Hero
{
    [RequireComponent(typeof(HeroAnimations), typeof(CharacterController))]
    public class HeroStateMachine : MonoBehaviour
    {
        [field: SerializeField] public Transform Hero { get; private set; }
        

        
        public CharacterController CharacterController { get; private set; }
        public HeroAnimations Animations { get; private set; }
        private BossAnimations BossAnimations { get; set; }
        
        public InputJoystickReceiver Input { get; private set; }
        public bool IsMagnetism { get; set; }

        private HeroBaseState _currentState;
        private readonly HeroMoveAndPunchState _moveAndPunchState = new HeroMoveAndPunchState();

        #region Execution

        public void Construct(InputJoystickReceiver input, BossAnimations bossAnimations)
        {
            Input = input;
            BossAnimations = bossAnimations;
        }

        private void Awake()
        {
            Animations = GetComponent<HeroAnimations>();
            CharacterController = GetComponent<CharacterController>();
        }

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