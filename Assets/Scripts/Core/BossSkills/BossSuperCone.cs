using System;
using System.Collections;
using Core.Animations;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Core.BossSkills
{
    public class BossSuperCone : MonoBehaviour
    {
        [SerializeField] private LookAtTarget _lookAtTarget;
        [SerializeField] private GameObject _cone;
        private BossAnimations _bossAnimations;
        private HeroAnimations _heroAnimations;
        private static readonly int _farPlane = Shader.PropertyToID("_FarPlane");
        private MeshRenderer _meshRenderer;
        public float AngleToHero { get; private set; }
        public float DistanceToHero { get; private set; }

        public void Construct(BossAnimations bossAnimations, HeroAnimations heroAnimations)
        {
            _heroAnimations = heroAnimations;
            _bossAnimations = bossAnimations;
        }

        private void Start()
        {
            _meshRenderer = _cone.GetComponent<MeshRenderer>();
            _meshRenderer.sharedMaterial.SetFloat(_farPlane, 0);
        }

        [ContextMenu("StartCharging")]
        public void Charging()
        {
            StartCoroutine(StartCharging());
        }

        public IEnumerator StartCharging()
        {
            _bossAnimations.SuperConeAnimation(); // Carefully animation event exist
            _lookAtTarget.IsLooking = false;

            StartCoroutine(IncreaseConeCoroutine());
            yield return new WaitForSeconds(2);

            _meshRenderer.sharedMaterial.SetFloat(_farPlane, 0);

            var directionToHero = (_heroAnimations.transform.position - transform.position).normalized;
            AngleToHero = Vector3.Angle(transform.forward, directionToHero);

            DistanceToHero = Vector3.Distance(transform.position, _heroAnimations.transform.position);

            yield return null;
        }

        private IEnumerator IncreaseConeCoroutine()
        {
            var farPlaneValue = 0f;
            while (_meshRenderer.sharedMaterial.GetFloat(_farPlane) < 1)
            {
                farPlaneValue += Time.deltaTime;
                _meshRenderer.sharedMaterial.SetFloat(_farPlane, farPlaneValue);

                yield return null;
            }
        }
        
    }
}