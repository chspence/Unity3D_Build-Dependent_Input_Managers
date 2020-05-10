public class GameEventListener
{
    public ParameterizedUnityEvent<object[]> Response { get; set; }

    public void OnEventRaised(object[] parameters)
    {
        Response.Invoke(parameters);
    }
}
