using System;
using System.Collections.Generic;
using System.Linq;
using Core.StateMachine.Hero;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.UI
{
    public class DamageInfoArea : MonoBehaviour
    {
        [SerializeField] [Range(0, 1)] private float _randomX;
        [SerializeField] [Range(0, 1)] private float _randomY;

        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            transform.LookAt(transform.position + _camera.transform.forward);
        }

        [SerializeField] private List<DamageText> _damageTextPool;

        public void ShowNewText()
        {
            var text = _damageTextPool.FirstOrDefault(x => x.gameObject.activeInHierarchy == false);
            text.SetValue(Random.Range(100, 1000));

            var newImagePosition = new Vector3(Random.Range(-_randomY, _randomX + 1),
                Random.Range(0, _randomY + 1), 0);
            
            text.EnableAndSetLocalPosition(newImagePosition);
        }
    }
}