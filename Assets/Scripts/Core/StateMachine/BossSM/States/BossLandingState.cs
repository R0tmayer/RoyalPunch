﻿using System.Collections;
using UnityEngine;

namespace Core.StateMachine.BossSM.States
{
    public class BossLandingState : BossBassState
    {
        private BossAnimations _animations;
        private MeshRenderer _circleMeshRenderer;
        private static readonly int _farPlane = Shader.PropertyToID("_FarPlane");

        #region Execution

        public override void EnterState(BossStateMachine stateMachine)
        {
            _animations = stateMachine.Animations;
            _circleMeshRenderer = stateMachine.Circle;

            _animations.SetLandingBool(true);
            stateMachine.LookAtTarget.Enabled = false;

            // push hero 

            stateMachine.StartCustomCoroutine(IncreaseCircle());
            stateMachine.StartCustomCoroutine(SetIdleStateAfterDelay(stateMachine));
        }

        public override void ExitState(BossStateMachine stateMachine)
        {
        }

        public override void UpdateState(BossStateMachine stateMachine)
        {
        }

        public override void OnCollisionEnter(BossStateMachine stateMachine, Collision collision)
        {
        }

        public override void OnTriggerExit(BossStateMachine stateMachine, Collider other)
        {
        }

        public override void OnTriggerStay(BossStateMachine stateMachine, Collider other)
        {
        }

        public override void OnTriggerEnter(BossStateMachine stateMachine, Collider other)
        {
        }

        #endregion

        private IEnumerator SetIdleStateAfterDelay(BossStateMachine stateMachine)
        {
            var delay = stateMachine.LandingTime + stateMachine.BoredTime;
            yield return new WaitForSeconds(delay);
            stateMachine.SetIdleState();
        }

        private IEnumerator IncreaseCircle()
        {
            var farPlaneValue = 0f;
            while (_circleMeshRenderer.material.GetFloat(_farPlane) < 1)
            {
                farPlaneValue += Time.deltaTime * 1.15f;
                _circleMeshRenderer.material.SetFloat(_farPlane, farPlaneValue);

                yield return null;
            }

            const float circleLifeTime = 1.5f;
            yield return new WaitForSeconds(circleLifeTime);
            _circleMeshRenderer.material.SetFloat(_farPlane, 0);

        }
    }
}