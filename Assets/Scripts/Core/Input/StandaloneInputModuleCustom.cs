using UnityEngine.EventSystems;

namespace Core.Input
{
    public class StandaloneInputModuleCustom : StandaloneInputModule
    {
        public PointerEventData GetLastPointerEventDataPublic(int id) => GetLastPointerEventData(id);
    }
}