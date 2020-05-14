using UnityServices;
using UnityEngine;

namespace InteractionMapper
{
    public class AndroidInteractionMapper : InteractionMapper
    {
        public AndroidInteractionMapper(IUnityInputService unityInputService) : base(unityInputService)
        {
        }

        public override bool CheckSelection(out Vector3? vector3)
        {
            var touches = UnityInputService.GetTouches();
            if (touches != null && touches.Length == 1 && touches[0].phase == TouchPhase.Began)
            {
                vector3 = touches[0].position;
                return true;
            }

            vector3 = null;
            return false;
        }

        public override bool CheckDragging(out Vector3? vector3)
        {
            var touches = UnityInputService.GetTouches();
            vector3 = touches[0].position;
            return true;
        }

        public override bool CheckDragEnd(out Vector3? vector3)
        {
            throw new System.NotImplementedException();
        }
    }
}