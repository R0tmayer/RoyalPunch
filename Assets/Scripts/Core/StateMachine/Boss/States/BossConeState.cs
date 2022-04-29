using System.Collections;
using UnityEngine;

namespace Core.StateMachine.Boss.States
{
    public class BossConeState : BossBassState
    {
        private BossAnimations _animations;
        private MeshRenderer _coneMeshRenderer;
        private static readonly int _farPlane = Shader.PropertyToID("_FarPlane");

        #region Execution

        public override void EnterState(BossStateMachine stateMachine)
        {
            _animations = stateMachine.Animations;
            _coneMeshRenderer = stateMachine.Cone;

            _animations.SetConeBool(true);
            stateMachine.LookAtTarget.Enabled = false;


            stateMachine.StartCustomCoroutine(PushPlayerAfterDelay(stateMachine));
            stateMachine.StartCustomCoroutine(IncreaseCone());
            stateMachine.StartCustomCoroutine(SetIdleStateAfterDelay(stateMachine));
        }

        public override void ExitState(BossStateMachine stateMachine){ }
        public override void UpdateState(BossStateMachine stateMachine){ }

        public override void OnCollisionEnter(BossStateMachine stateMachine, Collision collision){ }

        public override void OnTriggerExit(BossStateMachine stateMachine, Collider other){ }

        public override void OnTriggerStay(BossStateMachine stateMachine, Collider other){ }

        public override void OnTriggerEnter(BossStateMachine stateMachine, Collider other){ }

        #endregion

        private IEnumerator PushPlayerAfterDelay(BossStateMachine stateMachine)
        {
            yield return new WaitForSeconds(stateMachine.ConeTime);

            var transform = stateMachine.transform;
            var heroTransform = stateMachine.HeroStateMachine.transform.position;

            var directionToHero = (heroTransform - transform.position).normalized;
            var angleToHero = Vector3.Angle(transform.forward, directionToHero);
            var distanceToHero = Vector3.Distance(transform.position, heroTransform);

            if (angleToHero < GameParameters.Instance.ConeAngleToHero &&
                distanceToHero < GameParameters.Instance.ConeDistance)
            {
                RagdollActivator.Instance.PushHero();
            }
        }

        private IEnumerator SetIdleStateAfterDelay(BossStateMachine stateMachine)
        {
            var delay = stateMachine.ConeTime + stateMachine.BoredTime;
            yield return new WaitForSeconds(delay);
            stateMachine.SetIdleState();
        }

        private IEnumerator IncreaseCone()
        {
            var farPlaneValue = 0f;
            while (_coneMeshRenderer.material.GetFloat(_farPlane) < 1)
            {
                farPlaneValue += Time.deltaTime * 1.15f;
                _coneMeshRenderer.material.SetFloat(_farPlane, farPlaneValue);

                yield return null;
            }

            const float coneLifeTime = 1.5f;
            yield return new WaitForSeconds(coneLifeTime);
            _coneMeshRenderer.material.SetFloat(_farPlane, 0);
        }
    }
}