using UnityEngine;

public class PcInteractionMapper : InteractionMapper
{
    public PcInteractionMapper(
        IUnityInputService unityInputService)
        : base(
            unityInputService)
    {
    }

    public override Vector3? CheckSelection()
    {
        if (!UnityInputService.GetMouseButtonDown(0)) return null;
        return UnityInputService.GetMousePosition();
    }

    //public override Vector3? CheckDragging()
    //{
    //    if (!UnityInputService.GetMouseButton(0) || UnityInputService.GetMouseButtonUp(0)) return null;
    //    return UnityInputService.GetMousePosition();
    //}

    //public override Vector3? CheckDragEnd()
    //{
    //    if (!UnityInputService.GetMouseButtonUp(0)) return null;
    //    return UnityInputService.GetMousePosition();
    //}
}