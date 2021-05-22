using SotnApi.Constants.Values.Game.Enums;

namespace SotnApi.Interfaces
{
    /// <returns>
    /// Controls
    /// </returns>
    public interface IGameApi
    {
        /// <returns>
        /// The current Status of the game.
        /// </returns>
        /// <example>
        /// MainMenu
        /// </example>
        /// <example>
        /// InGame
        /// </example>
        uint Status { get; }
        /// <returns>
        /// Returns the currently selected category in the menu.
        /// </returns>
        MainMenuCategory CurrentMainMenuCategory { get; }
        /// <returns>
        /// The current character, but prologue Richter still counts as Alucard.
        /// </returns>
        Character CurrentCharacter { get; }
        /// <returns>
        /// Index for the current area or subarea.
        /// </returns>
        uint Area { get; }
        /// <returns>
        /// Room for the current room or subroom.
        /// </returns>
        uint Room { get; }
        /// <returns>
        /// True if the player is in the second castle. 
        /// </returns>
        bool SecondCastle { get; }
        /// <returns>
        /// X coordinate for the current highlighted room on the map.
        /// </returns>
        uint MapXPos { get; }
        /// <returns>
        /// Y coordinate for the current highlighted room on the map.
        /// </returns>
        uint MapYPos { get; }
        /// <returns>
        /// Zone Byte1.
        /// </returns>
        uint Zone { get; }
        /// <returns>
        /// Zone Byte2.
        /// </returns>
        uint Zone2 { get; }
        /// <returns>
        /// True of the game is in the process of loading a new area.
        /// </returns>
        bool IsLoading { get; }
        /// <returns>
        /// True of the game is in the process of loading a new screen.
        /// </returns>
        bool InTransition { get; }

        /// <summary>
        /// Checks if the item equip menu is currently open.
        /// </summary>
        bool EquipMenuOpen();
        /// <summary>
        /// Checks if the relic equip menu is currently open.
        /// </summary>
        bool RelicMenuOpen();
        /// <summary>
        /// Checks if it is currently possible for the player to access the menu.
        /// </summary>
        bool CanMenu();
        /// <summary>
        /// Sets a room on the map to unvisited. Alucard can discover it again.
        /// </summary>
        void SetRoomToUnvisited(long address);
        /// <summary>
        /// Sets a room on the map to visited. It will not reflect on the map unless a map reload occurs. Library cards and castle switches reload the map.
        /// </summary>
        void SetRoomToVisited(long address);
        /// <summary>
        /// Sets the value for a room on the map. It will not reflect on the map unless a map reload occurs. Library cards and castle switches reload the map.
        /// </summary>
        void SetRoomValue(long address, byte value);
        /// <summary>
        /// Checks if the game is in Alucard mode.
        /// </summary>
        bool InAlucardMode();
        /// <summary>
        /// Checks if the game is the Prologue.
        /// </summary>
        bool InPrologue();
        /// <summary>
        /// Checks if the player is in a save room.
        /// </summary>
        bool CanSave();
        /// <summary>
        /// Checks if the menu si currently open.
        /// </summary>
        bool IsInMenu();
        /// <summary>
        /// Overwrites a string in the game.
        /// </summary>
        void OverwriteString(long address, string text);
        /// <summary>
        /// Reads the start menu string, where the  Randomizer preset is stored.
        /// </summary>
        string ReadPresetName();
        /// <summary>
        /// Reads the start menu string, where the  Randomizer seed is stored.
        /// </summary>
        string ReadSeedName();
        /// <summary>
        /// Enables all the bosses in the game, even if they have been defeated.
        /// </summary>
        void RespawnBosses();
    }
}