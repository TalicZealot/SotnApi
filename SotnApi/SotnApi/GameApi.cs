﻿using BizHawk.Client.Common;
using SotnApi.Constants.Addresses;
using SotnApi.Constants.Addresses.Alucard;
using SotnApi.Constants.Values.Game;
using SotnApi.Constants.Values.Game.Enums;
using SotnApi.Interfaces;
using SotnApi.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SotnApi
{
    public sealed class GameApi : IGameApi
    {
        private const int MaxStringLenght = 31;
        private readonly IMemoryApi memAPI;
        public GameApi(IMemoryApi? memAPI)
        {
            if (memAPI == null) { throw new ArgumentNullException(nameof(memAPI)); }

            this.memAPI = memAPI;
            ZoneTransitions = new Dictionary<Zone, Dictionary<Zone, ZoneTransition>>()
            {
                {
                    Zone.CastleEntrance,
                    new Dictionary<Zone, ZoneTransition>()
                    {
                        { Zone.MarbleGallery, new ZoneTransition(ZoneTransitionAddresses.CastleEntrance[Zone.MarbleGallery], memAPI) },
                        { Zone.UndergroundCaverns, new ZoneTransition(ZoneTransitionAddresses.CastleEntrance[Zone.UndergroundCaverns], memAPI) },
                        { Zone.AlchemyLaboratory, new ZoneTransition(ZoneTransitionAddresses.CastleEntrance[Zone.AlchemyLaboratory], memAPI) },
                        { Zone.Warp, new ZoneTransition(ZoneTransitionAddresses.CastleEntrance[Zone.Warp], memAPI) },
                    }
                },
                {
                    Zone.AlchemyLaboratory,
                    new Dictionary<Zone, ZoneTransition>()
                    {
                        { Zone.CastleEntrance, new ZoneTransition(ZoneTransitionAddresses.AlchemyLaboratory[Zone.CastleEntrance], memAPI) },
                        { Zone.MarbleGallery, new ZoneTransition(ZoneTransitionAddresses.AlchemyLaboratory[Zone.MarbleGallery], memAPI) },
                        { Zone.RoyalChapel, new ZoneTransition(ZoneTransitionAddresses.AlchemyLaboratory[Zone.RoyalChapel], memAPI) },
                    }
                },
                {
                    Zone.Colosseum,
                    new Dictionary<Zone, ZoneTransition>()
                    {
                        {Zone.RoyalChapel, new ZoneTransition(ZoneTransitionAddresses.Colosseum[Zone.RoyalChapel], memAPI)},
                        {Zone.OlroxsQuarters, new ZoneTransition(ZoneTransitionAddresses.Colosseum[Zone.OlroxsQuarters], memAPI)},
                    }
                },
                {
                    Zone.OlroxsQuarters,
                    new Dictionary<Zone, ZoneTransition>()
                    {
                        { Zone.MarbleGallery, new ZoneTransition(ZoneTransitionAddresses.OlroxsQuarters[Zone.MarbleGallery], memAPI) },
                        { Zone.RoyalChapel, new ZoneTransition(ZoneTransitionAddresses.OlroxsQuarters[Zone.RoyalChapel], memAPI) },
                        { Zone.Colosseum, new ZoneTransition(ZoneTransitionAddresses.OlroxsQuarters[Zone.Colosseum], memAPI) },
                        { Zone.Warp, new ZoneTransition(ZoneTransitionAddresses.OlroxsQuarters[Zone.Warp], memAPI) },
                    }
                },
                {
                    Zone.RoyalChapel,
                    new Dictionary<Zone, ZoneTransition>()
                    {
                        { Zone.OlroxsQuarters, new ZoneTransition(ZoneTransitionAddresses.RoyalChapel[Zone.OlroxsQuarters], memAPI) },
                        { Zone.Colosseum, new ZoneTransition(ZoneTransitionAddresses.RoyalChapel[Zone.Colosseum], memAPI) },
                        { Zone.AlchemyLaboratory, new ZoneTransition(ZoneTransitionAddresses.RoyalChapel[Zone.AlchemyLaboratory], memAPI) },
                        { Zone.CastleKeep, new ZoneTransition(ZoneTransitionAddresses.RoyalChapel[Zone.CastleKeep], memAPI) },
                    }
                },
                {
                    Zone.Warp,
                    new Dictionary<Zone, ZoneTransition>()
                    {
                        { Zone.CastleKeep, new ZoneTransition(ZoneTransitionAddresses.Warp[Zone.CastleKeep], memAPI) },
                        { Zone.OuterWall, new ZoneTransition(ZoneTransitionAddresses.Warp[Zone.OuterWall], memAPI) },
                        { Zone.OlroxsQuarters, new ZoneTransition(ZoneTransitionAddresses.Warp[Zone.OlroxsQuarters], memAPI) },
                        { Zone.CastleEntrance, new ZoneTransition(ZoneTransitionAddresses.Warp[Zone.CastleEntrance], memAPI) },
                        { Zone.AbandonedMine, new ZoneTransition(ZoneTransitionAddresses.Warp[Zone.AbandonedMine], memAPI) },
                    }
                },
                {
                    Zone.MarbleGallery,
                    new Dictionary<Zone, ZoneTransition>()
                    {
                        { Zone.AlchemyLaboratory, new ZoneTransition(ZoneTransitionAddresses.MarbleGallery[Zone.AlchemyLaboratory], memAPI) },
                        { Zone.OlroxsQuarters, new ZoneTransition(ZoneTransitionAddresses.MarbleGallery[Zone.OlroxsQuarters], memAPI) },
                        { Zone.OuterWall, new ZoneTransition(ZoneTransitionAddresses.MarbleGallery[Zone.OuterWall], memAPI) },
                        { Zone.CastleEntrance, new ZoneTransition(ZoneTransitionAddresses.MarbleGallery[Zone.CastleEntrance], memAPI) },
                        { Zone.UndergroundCaverns, new ZoneTransition(ZoneTransitionAddresses.MarbleGallery[Zone.UndergroundCaverns], memAPI) },
                        { Zone.CenterCube, new ZoneTransition(ZoneTransitionAddresses.MarbleGallery[Zone.CenterCube], memAPI) },
                    }
                },
                {
                    Zone.LongLibrary,
                    new Dictionary<Zone, ZoneTransition>()
                    {
                        { Zone.OuterWall, new ZoneTransition(ZoneTransitionAddresses.LongLibrary[Zone.OuterWall], memAPI) },
                    }
                },
                {
                    Zone.ClockTower,
                    new Dictionary<Zone, ZoneTransition>()
                    {
                        { Zone.CastleKeep, new ZoneTransition(ZoneTransitionAddresses.ClockTower[Zone.CastleKeep], memAPI) },
                        { Zone.OuterWall, new ZoneTransition(ZoneTransitionAddresses.ClockTower[Zone.OuterWall], memAPI) },
                    }
                },
                {
                    Zone.CastleKeep,
                    new Dictionary<Zone, ZoneTransition>()
                    {
                        { Zone.ClockTower, new ZoneTransition(ZoneTransitionAddresses.CastleKeep[Zone.ClockTower], memAPI) },
                        { Zone.Warp, new ZoneTransition(ZoneTransitionAddresses.CastleKeep[Zone.Warp], memAPI) },
                        { Zone.RoyalChapel, new ZoneTransition(ZoneTransitionAddresses.CastleKeep[Zone.RoyalChapel], memAPI) },
                    }
                },
                {
                    Zone.UndergroundCaverns,
                    new Dictionary<Zone, ZoneTransition>()
                    {
                        { Zone.AbandonedMine, new ZoneTransition(ZoneTransitionAddresses.UndergroundCaverns[Zone.AbandonedMine], memAPI) },
                        { Zone.MarbleGallery, new ZoneTransition(ZoneTransitionAddresses.UndergroundCaverns[Zone.MarbleGallery], memAPI) },
                        { Zone.Nightmare, new ZoneTransition(ZoneTransitionAddresses.UndergroundCaverns[Zone.Nightmare], memAPI) },
                        { Zone.CastleEntrance, new ZoneTransition(ZoneTransitionAddresses.UndergroundCaverns[Zone.CastleEntrance], memAPI) },
                    }
                },
                {
                    Zone.AbandonedMine,
                    new Dictionary<Zone, ZoneTransition>()
                    {
                        { Zone.UndergroundCaverns, new ZoneTransition(ZoneTransitionAddresses.AbandonedMine[Zone.UndergroundCaverns], memAPI) },
                        { Zone.Warp, new ZoneTransition(ZoneTransitionAddresses.AbandonedMine[Zone.Warp], memAPI) },
                        { Zone.Catacombs, new ZoneTransition(ZoneTransitionAddresses.AbandonedMine[Zone.Catacombs], memAPI) },
                    }
                },
                {
                    Zone.Catacombs,
                    new Dictionary<Zone, ZoneTransition>()
                    {
                        { Zone.AbandonedMine, new ZoneTransition(ZoneTransitionAddresses.Catacombs[Zone.AbandonedMine], memAPI) },
                    }
                },
                {
                    Zone.OuterWall,
                    new Dictionary<Zone, ZoneTransition>()
                    {
                        { Zone.MarbleGallery, new ZoneTransition(ZoneTransitionAddresses.OuterWall[Zone.MarbleGallery], memAPI) },
                        { Zone.LongLibrary, new ZoneTransition(ZoneTransitionAddresses.OuterWall[Zone.LongLibrary], memAPI) },
                        { Zone.Warp, new ZoneTransition(ZoneTransitionAddresses.OuterWall[Zone.Warp], memAPI) },
                        { Zone.ClockTower, new ZoneTransition(ZoneTransitionAddresses.OuterWall[Zone.ClockTower], memAPI) },
                    }
                },
            };
        }

        public uint Status
        {
            get
            {
                return memAPI.ReadByte(Game.Status);
            }
        }

        public MainMenuCategory CurrentMainMenuCategory
        {
            get
            {
                return (MainMenuCategory)memAPI.ReadByte(Game.MainMenuCategory);
            }
        }

        public Character CurrentCharacter
        {
            get
            {
                uint character = memAPI.ReadByte(Game.Character);
                if (character == 0)
                {
                    return Character.Alucard;
                }
                else
                {
                    return Character.Richter;
                }
            }
        }

        public Dictionary<Zone, Dictionary<Zone, ZoneTransition>> ZoneTransitions { get; }

        public bool SecondCastle
        {
            get
            {
                return memAPI.ReadByte(Game.SecondCastle) > 0;
            }
        }

        public uint RoomX
        {
            get
            {
                return memAPI.ReadByte(Game.MapXPos);
            }
        }

        public uint RoomY
        {
            get
            {
                return memAPI.ReadByte(Game.MapYPos);
            }
        }

        public uint Zone2
        {
            get
            {
                return memAPI.ReadByte(Game.Zone2);
            }
        }

        public uint Area
        {
            get
            {
                return memAPI.ReadByte(Game.Area);
            }
        }

        public uint Room
        {
            get
            {
                return memAPI.ReadByte(Game.Room);
            }
        }

        public uint Hours
        {
            get
            {
                return memAPI.ReadU16(Game.Hours);
            }
        }

        public uint Minutes
        {
            get
            {
                return memAPI.ReadU16(Game.Minutes);
            }
        }

        public uint Seconds
        {
            get
            {
                return memAPI.ReadU16(Game.Seconds);
            }
        }

        public uint Frames
        {
            get
            {
                return memAPI.ReadU16(Game.Frames);
            }
        }

        public bool UnderwaterPhysicsEnabled
        {
            get
            {
                return memAPI.ReadU16(Game.UnderwaterPhysics) > 0;
            }
            set
            {
                memAPI.WriteU16(Game.UnderwaterPhysics, value ? (uint)0x0090 : (uint)0x0000);
            }
        }

        public bool MapOpen
        {
            get
            {
                return memAPI.ReadByte(Game.MapOpen) > 0;
            }
        }

        public bool IsLoading
        {
            get
            {
                return memAPI.ReadByte(Game.Loading) == SotnApi.Constants.Values.Game.Status.Loading;
            }
        }

        public bool InTransition
        {
            get
            {
                return memAPI.ReadByte(Game.Transition) == SotnApi.Constants.Values.Game.Status.Transition;
            }
        }

        public uint MusicTrack
        {
            get
            {
                return memAPI.ReadByte(Game.MusicTrack);
            }
        }

        public uint TrackVolume
        {
            get
            {
                return memAPI.ReadByte(Game.TrackVolume);
            }
        }

        public uint MusicVolume
        {
            get
            {
                return memAPI.ReadByte(Game.MusicVolume);
            }
        }

        public bool EquipMenuOpen()
        {
            return memAPI.ReadByte(Game.EquipMenuOpen) > 0 && CurrentMainMenuCategory == MainMenuCategory.Equip;
        }

        public bool RelicMenuOpen()
        {
            return memAPI.ReadByte(Game.RelicMenuOpen) > 0 && CurrentMainMenuCategory == MainMenuCategory.Relics;
        }

        public bool CanMenu()
        {
            bool notTransition = !this.InTransition;
            bool notLoading = !this.IsLoading;
            return (notTransition && notLoading);
        }

        public bool IsInMenu()
        {
            bool menuOpen = memAPI.ReadByte(Game.MenuOpen) == SotnApi.Constants.Values.Game.Status.MenuOpen;
            return menuOpen;
        }

        public void RespawnBosses()
        {
            foreach (var boss in Game.BossToggles)
            {
                memAPI.WriteS32(boss.Value, 0);
            }
        }

        public void RespawnItems()
        {
            List<byte> bytes = new();
            for (int i = 0; i < Various.MapItemsCollectedSize; i++)
            {
                bytes.Add(0x00);
            }

            memAPI.WriteByteRange(Game.MapItemsCollectedStart, bytes);
        }

        public uint GetTimeAttack(string name)
        {
            if (TimeAttack.Times.ContainsKey(name.ToLower().Trim()))
            {
                return memAPI.ReadU32(TimeAttack.Times[name]);
            }
            return 0;
        }

        public bool InAlucardMode()
        {
            uint currentRoomXPos = RoomX;
            uint currentRoomYPos = RoomY;

            bool inGame = this.Status == SotnApi.Constants.Values.Game.Status.InGame;
            bool isAlucard = this.CurrentCharacter == Character.Alucard;
            bool notInPrologue = this.Area != Various.PrologueArea && this.Area > 0;
            bool prologueMapLocation = (currentRoomXPos >= 0 && currentRoomXPos <= 1) && (currentRoomYPos >= 0 && currentRoomYPos <= 2);
            if (this.Area == Various.PrologueArea && this.SecondCastle)
            {
                notInPrologue = true;
            }
            return (inGame && isAlucard && notInPrologue);
        }

        public bool InPrologue()
        {
            uint currentRoomXPos = RoomX;
            uint currentRoomYPos = RoomY;
            uint maxHp = memAPI.ReadU32(Stats.MaxHP);
            uint timeAttackPrologue = GetTimeAttack("draculaprologue");
            bool inGame = this.Status == SotnApi.Constants.Values.Game.Status.InGame;
            bool isAlucard = this.CurrentCharacter == Character.Alucard;

            bool notInPrologue = this.Area != Various.PrologueArea && this.Area > 0;

            if (this.Area == Various.PrologueArea && this.SecondCastle)
            {
                notInPrologue = true;
            }
            if (this.Area == 0 && !this.SecondCastle)
            {
                notInPrologue = true;
            }

            bool prologueMapLocation = (currentRoomXPos >= 0 && currentRoomXPos <= 1) && (currentRoomYPos >= 0 && currentRoomYPos <= 2);

            return (inGame && isAlucard && prologueMapLocation && timeAttackPrologue == 0 && maxHp == 50 && !notInPrologue);
        }

        public bool CanSave()
        {
            return (memAPI.ReadByte(Game.CanSave) & Various.CanSave) == Various.CanSave;
        }

        public bool CanWarp()
        {
            return (memAPI.ReadByte(Game.CanWarp) & Various.CanWarp) == Various.CanWarp;
        }

        /// <summary>
        /// Room is an index that goes in increments of 8. Setting XY outside of the room will cause a large amount of delay before gaining control.
        /// </summary>
        public void SetLibraryCardDestination(uint zone, int xpos, int ypos, uint room)
        {
            memAPI.WriteByte(Game.LibraryCardDestinationZone, zone);
            memAPI.WriteS16(Game.LibraryCardDestinationXpos, xpos);
            memAPI.WriteS16(Game.LibraryCardDestinationYpos, ypos);
            memAPI.WriteU16(Game.LibraryCardDestinationRoom, room);
        }

        public void SetMovementSpeedDirection(bool flipped = false)
        {
            if (flipped)
            {
                memAPI.WriteU32(Constants.Addresses.Game.MovementSpeedDirectionInstruction, Constants.Values.Game.Various.FlippedMovementSpeedDirectionInstruction);
            }
            else
            {
                memAPI.WriteU32(Constants.Addresses.Game.MovementSpeedDirectionInstruction, Constants.Values.Game.Various.DefaultMovementSpeedDirectionInstruction);
            }
        }

        public void OverwriteString(long address, string text, bool safe)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));
            if (text == String.Empty) throw new ArgumentException("Text cannot be empty!");

            bool endReached = false;

            for (int i = 0; i < MaxStringLenght; i++)
            {
                bool atEnd = false;
                if (memAPI.ReadByte(address + i) == 255)
                {
                    atEnd = true;
                    endReached = true;
                    if (safe)
                    {
                        return;
                    }
                }

                if (i < text.Length)
                {
                    memAPI.WriteByte(address + i, (uint)text[i] - 32);
                }
                else
                {
                    if (endReached)
                    {
                        memAPI.WriteByte(address + i, 255);
                        break;
                    }
                    else if (!atEnd)
                    {
                        memAPI.WriteByte(address + i, 0);
                    }
                }
            }
        }

        public void MuteXA()
        {
            memAPI.WriteU32(Constants.Addresses.Game.VolumeSetInstruction, Constants.Values.Game.Various.MuteVolumeSetInstruction);
        }

        public void UnmuteXA()
        {
            memAPI.WriteU32(Constants.Addresses.Game.VolumeSetInstruction, Constants.Values.Game.Various.DefaultVolumeSetInstruction);
        }

        public void EnableStartWithStereo()
        {
            memAPI.WriteU32(Constants.Addresses.Game.StartingStereoSettingInstruction, Constants.Values.Game.Various.StereoStartingStereoSettingInstruction);
        }
        public void SetRoomToUnvisited(long address)
        {
            if (address < Game.MapStart || address > Game.MapEnd) { throw new ArgumentOutOfRangeException(nameof(address), "Not a valid map address."); }
            memAPI.WriteByte(address, 0);
        }

        public void SetRoomToVisited(long address)
        {
            if (address < Game.MapStart || address > Game.MapEnd) { throw new ArgumentOutOfRangeException(nameof(address), "Not a valid map address."); }
            memAPI.WriteByte(address, 0xFF);
        }

        public void SetRoomValue(long address, byte value)
        {
            if (address < Game.MapStart || address > Game.MapEnd) { throw new ArgumentOutOfRangeException(nameof(address), "Not a valid map address."); }
            memAPI.WriteByte(address, value);
        }

        public string ReadSeedName()
        {
            return ReadString(Game.SeedStart);
        }

        public string ReadPresetName()
        {
            string preset = ReadString(Game.PresetStart).Trim();
            string pattern = @" ([a-z.-]{2,15})( ){0,1}";
            Match match = Regex.Match(preset, pattern, RegexOptions.IgnoreCase);
            return match.Value.Trim();
        }

        private string ReadString(long address)
        {
            string result = "";
            bool digit = false;
            bool symbol = false;

            for (int i = 0; i < MaxStringLenght; i++)
            {
                uint currentByte = memAPI.ReadByte(address + i);
                if (currentByte == 255 || currentByte == 0)
                {
                    break;
                }
                else if (currentByte == 130)
                {
                    digit = true;
                }
                else if (currentByte == 129)
                {
                    symbol = true;
                }
                else
                {
                    if (digit)
                    {
                        digit = false;
                        result += ((int)(currentByte - 79));
                    }
                    else if (symbol)
                    {
                        symbol = false;
                        if (Various.CharacterMap.ContainsKey(currentByte))
                        {
                            result += Various.CharacterMap[currentByte];
                        }
                    }
                    else if (currentByte > 0)
                    {
                        result += (char)((int)currentByte);
                    }
                }
            }

            return result;
        }
    }
}
