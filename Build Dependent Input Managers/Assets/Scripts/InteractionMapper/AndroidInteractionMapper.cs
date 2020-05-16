using System.Linq;
using UnityServices;
using UnityEngine;

namespace InteractionMapper
{
    public class AndroidInteractionMapper : InteractionMapper
    {
        private bool _currentlyDragging;
        private int _draggingFingerId;

        public AndroidInteractionMapper(IUnityInputService unityInputService) : base(unityInputService)
        {
            _currentlyDragging = false;
            _draggingFingerId = -1;
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
            if (
                touches != null
                && touches.Length == 1
                && (
                    touches[0].phase == TouchPhase.Began
                    || (
                        _currentlyDragging
                        && (
                            touches[0].phase == TouchPhase.Stationary
                            || touches[0].phase == TouchPhase.Moved
                            )
                        )
                    )
                )
            {
                _currentlyDragging = true;
                _draggingFingerId = touches[0].fingerId;

                vector3 = touches[0].position;
                return true;
            }

            _currentlyDragging = false;

            vector3 = null;
            return false;
        }

        public override bool CheckDragEnd(out Vector3? vector3)
        {
            var touches = UnityInputService.GetTouches();
            if (
                touches != null
                && _draggingFingerId != -1
                && (
                    touches.Length > 1 
                    || touches[0].phase == TouchPhase.Ended 
                    || touches[0].phase == TouchPhase.Canceled
                    )
                )
            {
                vector3 = touches.Single(x => x.fingerId == _draggingFingerId).position;
                _draggingFingerId = -1;
                return true;
            }

            vector3 = null;
            return false;
        }
    }
}