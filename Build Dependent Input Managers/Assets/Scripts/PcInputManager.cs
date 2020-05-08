public class PcInputManager : InputManager
{
    public override void CheckForSelection()
    {
        if (!UnityInputService.GetMouseButtonDown(1) || UnityInputService.GetMouseButtonUp(1)) return;

        InteractionPositionVector3Variable.Value = UnityInputService.GetMousePosition();
        OnSelectionGameEvent.Raise();
    }

    public override void CheckForDragging()
    {
        if (UnityInputService.GetMouseButton(1) && !UnityInputService.GetMouseButtonUp(1))
            OnDraggingGameEvent.Raise();
    }

    public override void CheckForDragEnd()
    {
        if (UnityInputService.GetMouseButtonUp(1))
            OnDragEndGameEvent.Raise();
    }

    public PcInputManager(IUnityInputService unityInputService,
        IGameEvent onSelectionGameEvent,
        IGameEvent onDraggingGameEvent,
        IGameEvent onDragEndGameEvent, 
        IVector3Variable interactionPositionVector3Variable)
        : base(
            unityInputService,
            onSelectionGameEvent,
            onDraggingGameEvent,
            onDragEndGameEvent,
            interactionPositionVector3Variable)
    { }
}
