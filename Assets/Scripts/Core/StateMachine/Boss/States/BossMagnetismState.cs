using System.Collections;
using Core.StateMachine.Hero;
using UnityEngine;

namespace Core.StateMachine.Boss.States
{
    public class BossMagnetismState : BossBassState
    {
        private BossAnimations _animations;

        #region Execution

        public override void EnterState(BossStateMachine stateMachine)
        {
            _animations = stateMachine.Animations;
            _animations.SetMagnetismBool(true);
            stateMachine.HeroStateMachine.IsMagnetism = true;
        }

        public override void ExitState(BossStateMachine stateMachine)
        {
            _animations.SetMagnetismBool(false);
            _animations.SetSuperPunchBool(false);
        }

        public override void UpdateState(BossStateMachine stateMachine){ }

        public override void OnCollisionEnter(BossStateMachine stateMachine, Collision collision){ }

        public override void OnTriggerExit(BossStateMachine stateMachine, Collider other){ }

        public override void OnTriggerStay(BossStateMachine stateMachine, Collider other){ }

        public override void OnTriggerEnter(BossStateMachine stateMachine, Collider other)
        {
            if(other.TryGetComponent(out HeroStateMachine _))
            {
                _animations.SetMagnetismBool(false);
                _animations.SetSuperPunchBool(true);
                stateMachine.LookAtTarget.Enabled = false;
                stateMachine.HeroStateMachine.IsMagnetism = false;
                stateMachine.StartCustomCoroutine(PushPlayerAfterDelay(stateMachine));
                stateMachine.StartCustomCoroutine(SetIdleStateAfterDelay(stateMachine));
            }
        }

        #endregion
        
        private IEnumerator PushPlayerAfterDelay(BossStateMachine stateMachine)
        {
            yield return new WaitForSeconds(stateMachine.SuperPunchTime);
            RagdollActivator.Instance.PushHero();
        }
        
        private IEnumerator SetIdleStateAfterDelay(BossStateMachine stateMachine)
        {
            yield return new WaitForSeconds(stateMachine.BoredTime);
            stateMachine.SetIdleState();
        }
    }
}