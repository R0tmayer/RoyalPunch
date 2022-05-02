using System;
using System.Collections;
using Cinemachine;
using UnityEngine;

namespace Core
{
    public class RagdollActivator : MonoBehaviour
    {
        public static RagdollActivator Instance;

        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Transform _rootBone;
        [SerializeField] private Rigidbody _pushBone;
        [SerializeField] private Animator _animator;
        [SerializeField] private Rigidbody[] _allRigidbodies;

        private float _lerp;

        public bool _isLerping;
        private Vector3[] _fallenBonesPositions;
        private Quaternion[] _fallenBonesAngles;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance == this)
            {
                Destroy(gameObject);
            }

            for (int i = 0; i < _allRigidbodies.Length; i++)
            {
                _allRigidbodies[i].isKinematic = true;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
                PushHero();

        }
        
        private void LateUpdate()
        {
            transform.position = new Vector3(transform.position.x, 2, transform.position.z);
            if(_isLerping == false)
                return;
            
            _lerp += GameParameters.Instance.StandUpLeprRate * Time.deltaTime;
            
            for (int i = 0; i < _allRigidbodies.Length; i++)
            {
                _allRigidbodies[i].transform.localPosition = Vector3.Lerp(_fallenBonesPositions[i],
                    _allRigidbodies[i].transform.localPosition, _lerp);

                _allRigidbodies[i].transform.rotation = Quaternion.Slerp(_fallenBonesAngles[i],
                    _allRigidbodies[i].transform.rotation, _lerp);

            }
        }

        [ContextMenu("PushHero")]
        public void PushHero()
        {
            _characterController.enabled = false;
            _animator.enabled = false;
            ActivateRagdoll();
            _pushBone.AddForce((-transform.forward + Vector3.up) * GameParameters.Instance.PushForce, ForceMode.Impulse);
            StartCoroutine(ReturnToIdlePositionAfterSleepTime());
        }

        private void ActivateRagdoll()
        {
            for (int i = 0; i < _allRigidbodies.Length; i++)
            {
                _allRigidbodies[i].isKinematic = false;
            }
        }

        private IEnumerator ReturnToIdlePositionAfterSleepTime()
        {
            yield return new WaitForSeconds(GameParameters.Instance.RagdollSleepTime);
            
            CacheFallenBones();
            ResetArmatureToZeroAndMovePrefabToArmature();
            _characterController.enabled = true;
            _animator.enabled = true;
            DeactivateRagdoll();
            
            _isLerping = true;
            _lerp = 0;

            while (_lerp < 1)
            {
                yield return null;
            }

            _isLerping = false;
        }

        private void CacheFallenBones()
        {
            _fallenBonesPositions = new Vector3[_allRigidbodies.Length];
            _fallenBonesAngles = new Quaternion[_allRigidbodies.Length];

            for (int i = 0; i < _allRigidbodies.Length; i++)
            {
                _fallenBonesPositions[i] = _allRigidbodies[i].transform.localPosition;
                _fallenBonesAngles[i] = Quaternion.Euler(_allRigidbodies[i].transform.localEulerAngles);
            }
        }
        
        private void ResetArmatureToZeroAndMovePrefabToArmature()
        {
            var armatureGlobalPosition = _rootBone.position;
            _rootBone.localPosition = Vector3.zero;
            transform.position = armatureGlobalPosition;
        }

        private void DeactivateRagdoll()
        {
            for (int i = 0; i < _allRigidbodies.Length; i++)
            {
                _allRigidbodies[i].isKinematic = true;
            }
        }
    }
}