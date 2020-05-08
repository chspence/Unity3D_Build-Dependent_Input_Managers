using UnityEngine;

public interface IUnityInputService
{
    bool GetMouseButtonDown(int number);
    bool GetMouseButton(int number);
    bool GetMouseButtonUp(int number);
    Vector3 GetMousePosition();
}
