using UnityEngine;

namespace UnityServices
{
    public interface IUnityInputService
    {
        Vector3 GetMousePosition();
        bool GetMouseButtonDown(int button);
        bool GetMouseButton(int button);
        bool GetMouseButtonUp(int button);
        Touch[] GetTouches();
    }
}
