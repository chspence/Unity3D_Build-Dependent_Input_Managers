using UnityEngine;

public abstract class InteractionMapper : IPlatformInteractionMapper
{
    protected IUnityInputService UnityInputService;

    protected InteractionMapper(
        IUnityInputService unityInputService)
    {
        UnityInputService = unityInputService;
    }

    public abstract Vector3? CheckSelection();
    //public abstract Vector3? CheckDragging();
    //public abstract Vector3? CheckDragEnd();
}