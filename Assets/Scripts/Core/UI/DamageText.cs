using System;
using Core.StateMachine.Hero;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Core.UI
{
    public class DamageText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private float _duration;
        [SerializeField] private float _movementY;
        [SerializeField] private Ease _ease;

        private Vector3 _startPosition;
        private object _hitImageLeft;

        private void Awake()
        {
            _startPosition = transform.localPosition;
        }

        private void OnEnable()
        {
            _text.DOFade(0, _duration).SetEase(_ease);

            transform.DOLocalMoveY(_movementY, _duration)
                .SetRelative(true)
                .SetEase(_ease)
                .OnComplete(() => gameObject.SetActive(false));
        }

        private void OnDisable()
        {
             transform.localPosition = _startPosition;
        }

        public void SetValue(int value) => _text.SetText("{0:0}", value);
        public void EnableAndSetLocalPosition(Vector3 position)
        {
            gameObject.SetActive(true);
            
            var color = _text.color;
            color.a = 1;
            _text.color = color;
            
            transform.localPosition = position;
        }
    }
}