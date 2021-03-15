using SotnApi.Constants.Values.Game.Enums;

namespace SotnApi.Interfaces
{
    public interface IGameApi
    {
        uint Status { get; }
        /// <returns>
        /// The current character, but prologue Richter still counts as Alucard.
        /// </returns>
        Character CurrentCharacter { get; }
        uint Area { get; }
        uint Room { get; }
        uint SecondCastle { get; }
        uint Zone { get; }
        uint Zone2 { get; }
        bool IsLoading { get; }
        bool InTransition { get; }

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