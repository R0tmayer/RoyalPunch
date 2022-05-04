using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Core.StateMachine.Hero;
using DG.Tweening;
using UnityEngine;

namespace Core
{
    public class RagdollActivator : MonoBehaviour
    {
        public static RagdollActivator Instance;

        [SerializeField] private CharacterController _characterController;
        [SerializeField] private GameObject _armature;
        [SerializeField] private Rigidbody _pushBone;
        [SerializeField] private Animator _animator;

        private List<Rigidbody> _allBones = new List<Rigidbody>();
        private List<Vector3> _startPositionsBones = new List<Vector3>();
        private List<Quaternion> _startQuaternionsBones = new List<Quaternion>();
        private GameObject _instantiate;

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
        }

        private void Start()
        {
            _armature.SetActive(false);
            StartCoroutine(CacheBones());
        }

        private IEnumerator CacheBones()
        {
            yield return new WaitForSeconds(0.1f);
            GetAllRigidbodies(_armature);
        }

        private void GetAllRigidbodies(GameObject parent)
        {
            foreach(Transform children in parent.transform)
            {
                if(children == null)
                {
                    return;
                }

                if(children.TryGetComponent(out Rigidbody rigidbody))
                {
                    _allBones.Add(rigidbody);
                    _startQuaternionsBones.Add(rigidbody.transform.rotation);
                    _startPositionsBones.Add(rigidbody.transform.localPosition);
                }

                GetAllRigidbodies(children.gameObject);
            }
        }

        private void Update()
        {
            transform.position = new Vector3(transform.position.x, 2, transform.position.z);
            
            if (Input.GetKeyDown(KeyCode.A))
                PushHero();
        }

        [ContextMenu("PushHero")]
        public void PushHero()
        {
            _characterController.enabled = false;
            _animator.enabled = false;
            _armature.SetActive(true);
            _pushBone.AddForce((-transform.forward + Vector3.up) * GameParameters.Instance.PushForce,
                ForceMode.Impulse);
            StartCoroutine(ReturnToIdlePositionAfterSleepTime());
        }

        private IEnumerator ReturnToIdlePositionAfterSleepTime()
        {
            yield return new WaitForSeconds(GameParameters.Instance.RagdollSleepTime);
            
            for(int i = 0; i < _allBones.Count; i++)
            {
                _allBones[i].transform.DOLocalMove(_startPositionsBones[i], 1);
                _allBones[i].transform.DORotateQuaternion(_startQuaternionsBones[i], 1);
            }
            yield return new WaitForSeconds(1);

            _armature.SetActive(false);

            _characterController.enabled = true;
            _animator.enabled = true;
            StopCoroutine(ReturnToIdlePositionAfterSleepTime());

        }
    }
}