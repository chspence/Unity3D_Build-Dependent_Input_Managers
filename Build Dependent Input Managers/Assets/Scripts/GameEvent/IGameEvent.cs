public interface IGameEvent
{
    void Raise(params object[] parameters);
}