public abstract class InputManager : IInputManager
{
    protected IUnityInputService UnityInputService;
    protected IGameEvent OnSelectionGameEvent;
    protected IGameEvent OnDraggingGameEvent;
    protected IGameEvent OnDragEndGameEvent;
    protected IVector3Variable InteractionPositionVector3Variable;

    protected InputManager(
        IUnityInputService unityInputService,
        IGameEvent onSelectionGameEvent,
        IGameEvent onDraggingGameEvent,
        IGameEvent onDragEndGameEvent,
        IVector3Variable interactionPositionVector3Variable)
    {
        UnityInputService = unityInputService;
        OnSelectionGameEvent = onSelectionGameEvent;
        OnDraggingGameEvent = onDraggingGameEvent;
        OnDragEndGameEvent = onDragEndGameEvent;
        InteractionPositionVector3Variable = interactionPositionVector3Variable;
    }

    public abstract void CheckForSelection();
    public abstract void CheckForDragging();
    public abstract void CheckForDragEnd();
}