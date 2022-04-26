using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.Input
{
    public class InputSwipeReceiver : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private float _sensitivity;
        [SerializeField] private StandaloneInputModuleCustom _standaloneInput;
        private int? _id;

        public float DeltaX { get; private set; }

        private void Update()
        {
            if (_id != null) 
                DeltaX = _standaloneInput.GetLastPointerEventDataPublic(_id.Value).delta.x * _sensitivity;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _id = eventData.pointerId;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _id = null;
            DeltaX = 0;
        }
    }
}