using UnityEngine;

public interface IUnityInputService
{
    Vector3 GetMousePosition();
    bool GetMouseButtonDown(int number);
    bool GetMouseButton(int number);
    bool GetMouseButtonUp(int number);
}
