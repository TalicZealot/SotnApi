namespace SotnApi.Interfaces
{
    public interface ISotnApi
    {
        IGameApi GameApi { get; }
        IAlucardApi AlucardApi { get; }
        IActorApi ActorApi { get; }
        IRenderingApi RenderingApi { get; }
    }
}
