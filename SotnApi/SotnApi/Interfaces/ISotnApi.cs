namespace SotnApi.Interfaces
{
    public interface ISotnApi
    {
        IGameApi GameApi { get; }
        IAlucardApi AlucardApi { get; }
        IEntityApi EntityApi { get; }
        IRenderingApi RenderingApi { get; }
    }
}
