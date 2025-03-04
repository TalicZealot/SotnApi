﻿using System.Collections.Generic;
using SotnApi.Constants.Values.Game.Enums;
using SotnApi.Models;

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
        /// Zone transitions. Doesn't include cutscene and boss transitions.
        /// </returns>
        public Dictionary<Stage, Dictionary<Stage, ZoneTransition>> ZoneTransitions { get; }
        /// <returns>
        /// Index for the current area or subarea.
        /// </returns>
        uint Area { get; }
        /// <returns>
        /// Room for the current room or subroom.
        /// </returns>
        uint Room { get; }
        /// <returns>
        /// Hours of in-game time.
        /// </returns>
        uint Hours { get; }
        /// <returns>
        /// Minutes of in-game time.
        /// </returns>
        uint Minutes { get; }
        /// <returns>
        /// Seconds of in-game time.
        /// </returns>
        uint Seconds { get; }
        /// <returns>
        /// Frames of in-game time.
        /// </returns>
        uint Frames { get; }
        /// <summary>
        /// Gets or sets underwater physics state.
        /// </summary>
        bool UnderwaterPhysicsEnabled { get; set; }
        /// <returns>
        /// True if the player is in the second castle. 
        /// </returns>
        bool SecondCastle { get; }
        /// <returns>
        /// X coordinate for the current highlighted room on the map.
        /// </returns>
        uint RoomX { get; }
        /// <returns>
        /// Y coordinate for the current highlighted room on the map.
        /// </returns>
        uint RoomY { get; }
        /// <returns>
        /// Shift for entity X positions based on how the camera moved.
        /// </returns>
        public float CameraAdjustmentX { get; }
        /// <returns>
        /// Shift for entity Y positions based on how the camera moved.
        /// </returns>
        public float CameraAdjustmentY { get; }
        /// <returns>
        /// Current StageId.
        /// </returns>
        uint StageId { get; }
        /// <returns>
        /// True of the map is open.
        /// </returns>
        bool MapOpen { get; }
        /// <returns>
        /// True of the game is in the process of loading a new area.
        /// </returns>
        bool IsLoading { get; }
        /// <returns>
        /// True of the game is in the process of loading a new screen.
        /// </returns>
        bool InTransition { get; }
        /// <returns>
        /// Index of the current music track. Would need to be frozen to get set.
        /// </returns>
        uint MusicTrack { get; }
        /// <summary>
        /// Gets or sets the default volume for the current track.
        /// </summary>
        uint TrackVolume { get; }
        /// <summary>
        /// Gets or sets the current volume for XA music.
        /// </summary>
        uint MusicVolume { get; }
        /// <summary>
        /// State of the buttons on the controller.
        /// </summary>
        ushort InputFlags { get; }
        /// <summary>
        /// Counter for the QCF input sequence
        /// </summary>
        ushort QcfInputCounter { get; }
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
        /// Gets the current value of a map room by address.
        /// </summary>
        public byte GetRoomValue(long address);
        /// <summary>
        /// Gets the current value of a map room by index.
        /// </summary>
        public byte GetRoomValue(ushort index);
        /// <summary>
        /// Sets a room on the map to unvisited. Alucard can discover it again.
        /// </summary>
        void SetRoomToUnvisited(long address);
        /// <summary>
        /// Sets a room on the map to unvisited. Alucard can discover it again.
        /// </summary>
        public void SetRoomToUnvisited(ushort index);
        /// <summary>
        /// Sets a room on the map to visited. It will not reflect on the map unless a map reload occurs. Library cards and castle switches reload the map.
        /// </summary>
        void SetRoomToVisited(long address);
        /// <summary>
        /// Sets the value for a room on the map. It will not reflect on the map unless a map reload occurs. Library cards and castle switches reload the map.
        /// </summary>
        void SetRoomValue(long address, byte value);
        /// <returns>
        /// The value of the time attack for the provided activity.
        /// </returns>
        uint GetTimeAttack(string name);
        /// <summary>
        /// Checks if the game is in Alucard mode.
        /// </summary>
        bool InAlucardMode();
        /// <summary>
        /// Checks if the game is the Prologue.
        /// </summary>
        bool InPrologue();
        /// <summary>
        /// Checks if the player is in a warp room.
        /// </summary>
        bool CanWarp();
        /// <summary>
        /// Checks if the player is in a save room.
        /// </summary>
        bool CanSave();
        /// <summary>
        /// Checks if the menu si currently open.
        /// </summary>
        bool IsInMenu();
        /// <summary>
        /// Changes where the Library Card teleports the user to.
        /// </summary>
        void SetLibraryCardDestination(uint zone, int xpos, int ypos, uint room);
        /// <summary>
        /// Flips or resets the direction in which Alucard walks or jumps.
        /// </summary>
        void SetMovementSpeedDirection(bool flipped = false);
        /// <summary>
        /// Overwrites a string in the game.
        /// </summary>
        void OverwriteString(long address, string text, bool safe);
        /// <summary>
        /// Mutes volume for all XA track playback without affecting load times.
        /// </summary>
        void MuteXA();
        /// <summary>
        /// Unmutes volume for all XA track playback.
        /// </summary>
        void UnmuteXA();
        /// <summary>
        /// When revealing a new map squre the game will not check for the existing color.
        /// </summary>
        void RemoveMapRevealCheck();
        /// <summary>
        /// Sets or resets the duration of a stopwatch cast.
        /// </summary>
        void SetStopwatchTimer(byte value = 0);
        /// <summary>
        /// Enables stereo when starting a new game.
        /// </summary>
        void EnableStartWithStereo();
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
        /// <summary>
        /// Respawns items on the map that have been previously collected.
        /// </summary>
        void RespawnItems();
    }
}