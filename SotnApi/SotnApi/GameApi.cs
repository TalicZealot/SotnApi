using BizHawk.Client.Common;
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
            ZoneTransitions = new Dictionary<Stage, Dictionary<Stage, ZoneTransition>>()
            {
                {
                    Stage.CastleEntrance,
                    new Dictionary<Stage, ZoneTransition>()
                    {
                        { Stage.MarbleGallery, new ZoneTransition(ZoneTransitionAddresses.CastleEntrance[Stage.MarbleGallery], memAPI) },
                        { Stage.UndergroundCaverns, new ZoneTransition(ZoneTransitionAddresses.CastleEntrance[Stage.UndergroundCaverns], memAPI) },
                        { Stage.AlchemyLaboratory, new ZoneTransition(ZoneTransitionAddresses.CastleEntrance[Stage.AlchemyLaboratory], memAPI) },
                        { Stage.Warp, new ZoneTransition(ZoneTransitionAddresses.CastleEntrance[Stage.Warp], memAPI) },
                    }
                },
                {
                    Stage.AlchemyLaboratory,
                    new Dictionary<Stage, ZoneTransition>()
                    {
                        { Stage.CastleEntrance, new ZoneTransition(ZoneTransitionAddresses.AlchemyLaboratory[Stage.CastleEntrance], memAPI) },
                        { Stage.MarbleGallery, new ZoneTransition(ZoneTransitionAddresses.AlchemyLaboratory[Stage.MarbleGallery], memAPI) },
                        { Stage.RoyalChapel, new ZoneTransition(ZoneTransitionAddresses.AlchemyLaboratory[Stage.RoyalChapel], memAPI) },
                    }
                },
                {
                    Stage.Colosseum,
                    new Dictionary<Stage, ZoneTransition>()
                    {
                        {Stage.RoyalChapel, new ZoneTransition(ZoneTransitionAddresses.Colosseum[Stage.RoyalChapel], memAPI)},
                        {Stage.OlroxsQuarters, new ZoneTransition(ZoneTransitionAddresses.Colosseum[Stage.OlroxsQuarters], memAPI)},
                    }
                },
                {
                    Stage.OlroxsQuarters,
                    new Dictionary<Stage, ZoneTransition>()
                    {
                        { Stage.MarbleGallery, new ZoneTransition(ZoneTransitionAddresses.OlroxsQuarters[Stage.MarbleGallery], memAPI) },
                        { Stage.RoyalChapel, new ZoneTransition(ZoneTransitionAddresses.OlroxsQuarters[Stage.RoyalChapel], memAPI) },
                        { Stage.Colosseum, new ZoneTransition(ZoneTransitionAddresses.OlroxsQuarters[Stage.Colosseum], memAPI) },
                        { Stage.Warp, new ZoneTransition(ZoneTransitionAddresses.OlroxsQuarters[Stage.Warp], memAPI) },
                    }
                },
                {
                    Stage.RoyalChapel,
                    new Dictionary<Stage, ZoneTransition>()
                    {
                        { Stage.OlroxsQuarters, new ZoneTransition(ZoneTransitionAddresses.RoyalChapel[Stage.OlroxsQuarters], memAPI) },
                        { Stage.Colosseum, new ZoneTransition(ZoneTransitionAddresses.RoyalChapel[Stage.Colosseum], memAPI) },
                        { Stage.AlchemyLaboratory, new ZoneTransition(ZoneTransitionAddresses.RoyalChapel[Stage.AlchemyLaboratory], memAPI) },
                        { Stage.CastleKeep, new ZoneTransition(ZoneTransitionAddresses.RoyalChapel[Stage.CastleKeep], memAPI) },
                    }
                },
                {
                    Stage.Warp,
                    new Dictionary<Stage, ZoneTransition>()
                    {
                        { Stage.CastleKeep, new ZoneTransition(ZoneTransitionAddresses.Warp[Stage.CastleKeep], memAPI) },
                        { Stage.OuterWall, new ZoneTransition(ZoneTransitionAddresses.Warp[Stage.OuterWall], memAPI) },
                        { Stage.OlroxsQuarters, new ZoneTransition(ZoneTransitionAddresses.Warp[Stage.OlroxsQuarters], memAPI) },
                        { Stage.CastleEntrance, new ZoneTransition(ZoneTransitionAddresses.Warp[Stage.CastleEntrance], memAPI) },
                        { Stage.AbandonedMine, new ZoneTransition(ZoneTransitionAddresses.Warp[Stage.AbandonedMine], memAPI) },
                    }
                },
                {
                    Stage.MarbleGallery,
                    new Dictionary<Stage, ZoneTransition>()
                    {
                        { Stage.AlchemyLaboratory, new ZoneTransition(ZoneTransitionAddresses.MarbleGallery[Stage.AlchemyLaboratory], memAPI) },
                        { Stage.OlroxsQuarters, new ZoneTransition(ZoneTransitionAddresses.MarbleGallery[Stage.OlroxsQuarters], memAPI) },
                        { Stage.OuterWall, new ZoneTransition(ZoneTransitionAddresses.MarbleGallery[Stage.OuterWall], memAPI) },
                        { Stage.CastleEntrance, new ZoneTransition(ZoneTransitionAddresses.MarbleGallery[Stage.CastleEntrance], memAPI) },
                        { Stage.UndergroundCaverns, new ZoneTransition(ZoneTransitionAddresses.MarbleGallery[Stage.UndergroundCaverns], memAPI) },
                        { Stage.CenterCube, new ZoneTransition(ZoneTransitionAddresses.MarbleGallery[Stage.CenterCube], memAPI) },
                    }
                },
                {
                    Stage.LongLibrary,
                    new Dictionary<Stage, ZoneTransition>()
                    {
                        { Stage.OuterWall, new ZoneTransition(ZoneTransitionAddresses.LongLibrary[Stage.OuterWall], memAPI) },
                    }
                },
                {
                    Stage.ClockTower,
                    new Dictionary<Stage, ZoneTransition>()
                    {
                        { Stage.CastleKeep, new ZoneTransition(ZoneTransitionAddresses.ClockTower[Stage.CastleKeep], memAPI) },
                        { Stage.OuterWall, new ZoneTransition(ZoneTransitionAddresses.ClockTower[Stage.OuterWall], memAPI) },
                    }
                },
                {
                    Stage.CastleKeep,
                    new Dictionary<Stage, ZoneTransition>()
                    {
                        { Stage.ClockTower, new ZoneTransition(ZoneTransitionAddresses.CastleKeep[Stage.ClockTower], memAPI) },
                        { Stage.Warp, new ZoneTransition(ZoneTransitionAddresses.CastleKeep[Stage.Warp], memAPI) },
                        { Stage.RoyalChapel, new ZoneTransition(ZoneTransitionAddresses.CastleKeep[Stage.RoyalChapel], memAPI) },
                    }
                },
                {
                    Stage.UndergroundCaverns,
                    new Dictionary<Stage, ZoneTransition>()
                    {
                        { Stage.AbandonedMine, new ZoneTransition(ZoneTransitionAddresses.UndergroundCaverns[Stage.AbandonedMine], memAPI) },
                        { Stage.MarbleGallery, new ZoneTransition(ZoneTransitionAddresses.UndergroundCaverns[Stage.MarbleGallery], memAPI) },
                        { Stage.Nightmare, new ZoneTransition(ZoneTransitionAddresses.UndergroundCaverns[Stage.Nightmare], memAPI) },
                        { Stage.CastleEntrance, new ZoneTransition(ZoneTransitionAddresses.UndergroundCaverns[Stage.CastleEntrance], memAPI) },
                    }
                },
                {
                    Stage.AbandonedMine,
                    new Dictionary<Stage, ZoneTransition>()
                    {
                        { Stage.UndergroundCaverns, new ZoneTransition(ZoneTransitionAddresses.AbandonedMine[Stage.UndergroundCaverns], memAPI) },
                        { Stage.Warp, new ZoneTransition(ZoneTransitionAddresses.AbandonedMine[Stage.Warp], memAPI) },
                        { Stage.Catacombs, new ZoneTransition(ZoneTransitionAddresses.AbandonedMine[Stage.Catacombs], memAPI) },
                    }
                },
                {
                    Stage.Catacombs,
                    new Dictionary<Stage, ZoneTransition>()
                    {
                        { Stage.AbandonedMine, new ZoneTransition(ZoneTransitionAddresses.Catacombs[Stage.AbandonedMine], memAPI) },
                    }
                },
                {
                    Stage.OuterWall,
                    new Dictionary<Stage, ZoneTransition>()
                    {
                        { Stage.MarbleGallery, new ZoneTransition(ZoneTransitionAddresses.OuterWall[Stage.MarbleGallery], memAPI) },
                        { Stage.LongLibrary, new ZoneTransition(ZoneTransitionAddresses.OuterWall[Stage.LongLibrary], memAPI) },
                        { Stage.Warp, new ZoneTransition(ZoneTransitionAddresses.OuterWall[Stage.Warp], memAPI) },
                        { Stage.ClockTower, new ZoneTransition(ZoneTransitionAddresses.OuterWall[Stage.ClockTower], memAPI) },
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

        public Dictionary<Stage, Dictionary<Stage, ZoneTransition>> ZoneTransitions { get; }

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

        public uint StageId
        {
            get
            {
                return memAPI.ReadByte(Game.StageId);
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
