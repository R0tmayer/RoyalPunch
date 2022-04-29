using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.CustomInput
{
    public class InputJoystickReceiver : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        [SerializeField] [Required] private RectTransform _joystick;
        [SerializeField] [Required] private RectTransform _internalJoystick;
        private int? _currentFinger;
        private float _distanceRation;
        private Vector2 _initPos;

        private float _maxDistance;
        private Vector2 _direction;

        public bool Enabled { get; set; } = true;

        public Vector2 Direction => Enabled ? _direction : Vector2.zero;

        private void Awake()
        {
            _maxDistance = _joystick.rect.width / 2f;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (eventData.pointerId != _currentFinger) return;
            Vector2 direction = eventData.position - _initPos;
            _distanceRation = Mathf.Clamp01(direction.magnitude / _maxDistance);
            _direction = direction.normalized;
            SetJoystickPosition();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_currentFinger != null) return;
            ResetJoystickPosition();
            _joystick.position = eventData.position;
            _currentFinger = eventData.pointerId;
            _joystick.gameObject.SetActive(true);
            _initPos = eventData.position;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (_currentFinger != eventData.pointerId) return;
            _currentFinger = null;
            ResetJoystickPosition();
            _joystick.gameObject.SetActive(false);
        }

        private void SetJoystickPosition()
        {
            _internalJoystick.anchoredPosition = _direction * _distanceRation * _maxDistance;
        }

        private void ResetJoystickPosition()
        {
            _direction = Vector2.zero;
            _distanceRation = 0f;
            SetJoystickPosition();
        }
    }
}