using UnityEngine;
using UnityServices;

namespace InteractionMapper
{
    public class WindowsInteractionMapper : InteractionMapper
    {
        public WindowsInteractionMapper(IUnityInputService unityInputService) : base(unityInputService)
        {
        }

        public override bool CheckSelection(out Vector3? vector3)
        {
            if (UnityInputService.GetMouseButtonDown(0))
            {
                vector3 = UnityInputService.GetMousePosition();
                return true;
            }

            vector3 = null;
            return false;
        }

        public override bool CheckDragging(out Vector3? vector3)
        {
            if (UnityInputService.GetMouseButton(0) && !UnityInputService.GetMouseButtonUp(0))
            {
                vector3 = UnityInputService.GetMousePosition();
                return true;
            }

            vector3 = null;
            return false;
        }

        public override bool CheckDragEnd(out Vector3? vector3)
        {
            if (UnityInputService.GetMouseButtonUp(0))
            {
                vector3 = UnityInputService.GetMousePosition();
                return true;
            }

            vector3 = null;
            return false;
        }
    }
}