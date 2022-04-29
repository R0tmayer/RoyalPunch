using System;
using System.Collections;
using Core.Hero;
using UnityEngine;

namespace Core.BossSkills
{
    public class BossSuperLanding : MonoBehaviour
    {
        [SerializeField] private LookAtTarget _lookAtTarget;
        [SerializeField] private GameObject _circle;
        public static BossSuperLanding Instance;
        private BossAnimations _bossAnimations;
        private HeroAnimations _heroAnimations;
        private static readonly int _farPlane = Shader.PropertyToID("_FarPlane");
        private MeshRenderer _meshRenderer;

        // public void Construct(BossAnimations bossAnimation)
        // {
        //     _bossAnimations = bossAnimation;
        // }

        private void Awake()
        {
            Instance = this;
            _meshRenderer = _circle.GetComponent<MeshRenderer>();
        }


        [ContextMenu("StartLanding")]
        public void Landing()
        {
            StartCoroutine(StartCharging());
        }
        
        public IEnumerator StartCharging()
        {
            _bossAnimations.SuperLandingAnimation();
            _lookAtTarget.Enabled = false;
            StartCoroutine(IncreaseConeCoroutine());
            
            yield return new WaitForSeconds(2.5f);

            _meshRenderer.sharedMaterial.SetFloat(_farPlane, 0);

            yield return null;
        }
        
        private IEnumerator IncreaseConeCoroutine()
        {
            var farPlaneValue = 0f;
            while (_meshRenderer.sharedMaterial.GetFloat(_farPlane) < 1)
            {
                farPlaneValue += Time.deltaTime * 1.15f;
                _meshRenderer.sharedMaterial.SetFloat(_farPlane, farPlaneValue);

                yield return null;
            }
        }
    }
}