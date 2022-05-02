using Core.CustomInput;
using Core.StateMachine.Boss;
using Core.StateMachine.Hero.States;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Core.StateMachine.Hero
{
    public class HeroStateMachine : MonoBehaviour
    {
        [field: SerializeField] public BossAnimations BossAnimations { get; private set; }
        [field: SerializeField] public HeroAnimationStates Animations { get; private set; }
        [field: SerializeField] public Transform Hero { get; private set; }
        [field: SerializeField] public CharacterController CharacterController { get; private set; }
        [field: SerializeField] public InputJoystickReceiver Input { get; private set; }
        [SerializeField] private Image _hitImageLeft;
        [SerializeField] private Image _hitImageRight;
        public bool IsMagnetism { get; set; }

        private HeroBaseState _currentState;
        private readonly HeroMoveAndPunchState _moveAndPunchState = new HeroMoveAndPunchState();

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

        public void HitBossAnimationLeft()
        {
            BossAnimations.SetHitTrigger();
            _hitImageLeft.DOFade(1, 0.1f).OnComplete(() => _hitImageLeft.DOFade(0, 0.1f));
        }
        
        public void HitBossAnimationRight()
        {
            BossAnimations.SetHitTrigger();
            _hitImageRight.DOFade(1, 0.1f).OnComplete(() => _hitImageRight.DOFade(0, 0.1f));
        }

        #endregion
    }
}