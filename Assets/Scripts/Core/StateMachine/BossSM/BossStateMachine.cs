using System;
using System.Collections;
using Core.CustomInput;
using Core.StateMachine.BossSM.States;
using Core.StateMachine.HeroSM;
using UnityEngine;

namespace Core.StateMachine.BossSM
{
    public class BossStateMachine : MonoBehaviour
    {
        [field: SerializeField] public HeroStateMachine HeroStateMachine { get; private set; }
        [field: SerializeField] public BossAnimations Animations { get; private set; }
        [field: SerializeField] public LookAtTarget LookAtTarget { get; private set; }
        [field: SerializeField] public MeshRenderer Cone { get; private set; }
        [field: SerializeField] public MeshRenderer Circle { get; private set; }
        [field: SerializeField] public float LandingTime { get; private set; }
        [field: SerializeField] public float ConeTime { get; private set; }
        [field: SerializeField] public float BoredTime { get; private set; }
        [field: SerializeField] public float SuperPunchTime { get; private set; }

        private BossBassState _currentState;
        private BossIdleState _idleState = new BossIdleState();
        private BossPunchState _punchState = new BossPunchState();
        private BossLandingState _landingState = new BossLandingState();
        private BossConeState _coneState = new BossConeState();
        private BossMagnetismState _magnetismState = new BossMagnetismState();

        #region Execution

        private void Start()
        {
            _currentState = _idleState;
            _currentState.EnterState(this);
        }

        private void Update()
        {
            print(_currentState);
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

        private void OnTriggerStay(Collider other)
        {
            _currentState.OnTriggerStay(this, other);
        }

        private void OnTriggerExit(Collider other)
        {
            _currentState.OnTriggerExit(this, other);
        }

        #endregion

        #region Switch State Presets

        public void SetIdleState() => SwitchState(_idleState);

        public void SetPunchState() => SwitchState(_punchState);

        [ContextMenu("SetLandingState")]
        public void SetLandingState() => SwitchState(_landingState);
        
        [ContextMenu("SetConeState")]
        public void SetConeState() => SwitchState(_coneState);        
        
        [ContextMenu("SetMagnetismState")]
        public void SetMagnetismState() => SwitchState(_magnetismState);

        private void SwitchState(BossBassState state)
        {
            _currentState.ExitState(this);
            _currentState = state;
            _currentState.EnterState(this);
        }
        

        #endregion

        public void StartCustomCoroutine(IEnumerator coroutine) => StartCoroutine(coroutine);
    }
}