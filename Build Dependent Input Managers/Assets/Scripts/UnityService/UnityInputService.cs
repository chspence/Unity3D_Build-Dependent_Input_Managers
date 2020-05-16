using UnityEngine;

namespace UnityServices
{
    public class UnityInputService : IUnityInputService
    {
        public Vector3 GetMousePosition()
        {
            return Input.mousePosition;
        }

        public bool GetMouseButtonDown(int button)
        {
            return Input.GetMouseButtonDown(button);
        }

        public bool GetMouseButton(int button)
        {
            return Input.GetMouseButton(button);
        }

        public bool GetMouseButtonUp(int button)
        {
            return Input.GetMouseButtonUp(button);
        }

        public Touch[] GetTouches()
        {
            return Input.touches;
        }
    }
}
