using BizHawk.Client.Common;
using SotnApi.Constants.Addresses;
using SotnApi.Constants.Values.Game;
using SotnApi.Constants.Values.Game.Enums;
using SotnApi.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace SotnApi
{
    public class GameApi : IGameApi
    {
        private const int MaxStringLenght = 31;
        private readonly IMemoryApi memAPI;
        public GameApi(IMemoryApi? memAPI)
        {
            if (memAPI == null) { throw new ArgumentNullException(nameof(memAPI)); }

            this.memAPI = memAPI;
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

        public bool SecondCastle
        {
            get
            {
                return memAPI.ReadByte(Game.SecondCastle) > 0;
            }
        }

        public uint Zone
        {
            get
            {
                return memAPI.ReadByte(Game.Zone);
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

        public bool InAlucardMode()
        {
            bool inGame = this.Status == SotnApi.Constants.Values.Game.Status.InGame;
            bool isAlucard = this.CurrentCharacter == Character.Alucard;
            bool notInPrologue = this.Area != Various.PrologueArea && this.Area > 0 && this.Zone != Various.PrologueZone ;
            if (this.Area == Various.PrologueArea && this.Zone != Various.PrologueZone && this.SecondCastle)
            {
                notInPrologue = true;
            }
            return (inGame && isAlucard && notInPrologue);
        }

        public bool InPrologue()
        {
            bool inGame = this.Status == SotnApi.Constants.Values.Game.Status.InGame;
            bool isAlucard = this.CurrentCharacter == Character.Alucard;
            bool notInPrologue = this.Area != Various.PrologueArea && this.Area > 0 && this.Zone != Various.PrologueZone && this.SecondCastle;

            if (this.Area == Various.PrologueArea && this.Zone != Various.PrologueZone && this.SecondCastle)
            {
                notInPrologue = true;
            }
            if (this.Area == 0 && this.Zone == Various.LoadingZone && !this.SecondCastle)
            {
                notInPrologue = true;
            }

            return (inGame && isAlucard && !notInPrologue);
        }

        public void OverwriteString(long address, string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));
            if (text == String.Empty) throw new ArgumentException("Text cannot be empty!");

            string transformedText = text.ToUpper();
            for (int i = 0; i < MaxStringLenght; i++)
            {
                if (memAPI.ReadByte(address + i) == 255)
                {
                    return;
                }
                if (i < text.Length)
                {
                    memAPI.WriteByte(address + i, (uint)text[i] - 32);
                }
                else
                {
                    memAPI.WriteByte(address + i, 0);
                }
            }
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
            string pattern = @" ([a-z.]{2,10})( ){0,1}";
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
