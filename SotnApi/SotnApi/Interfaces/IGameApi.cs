namespace SotnApi.Interfaces
{
    public interface IGameApi
    {
        uint Area { get; }
        uint Room { get; }
        uint SecondCastle { get; }
        uint Zone { get; }
        uint Zone2 { get; }

        bool CanMenu();
        void ClearByte(long address);
        bool InAlucardMode();
        bool IsInMenu();
        void OverwriteString(long address, string text);
        string ReadPresetName();
        string ReadSeedName();
        void RespawnBosses();
    }
}