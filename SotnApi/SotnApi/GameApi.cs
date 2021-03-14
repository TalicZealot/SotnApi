﻿using System;
using BizHawk.Client.Common;
using SotnApi.Constants.Addresses;
using SotnApi.Constants.Values.Game;
using SotnApi.Constants.Values.Game.Enums;
using SotnApi.Interfaces;

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

        public uint SecondCastle
        {
            get
            {
                return memAPI.ReadByte(Game.SecondCastle);
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

        public bool CanMenu()
        {
            bool notTransition = memAPI.ReadByte(Game.StatusTransition) != Status.Transition;
            bool notLoading = memAPI.ReadByte(Game.Loading) != Status.Loading;
            return (notTransition && notLoading);
        }

        public bool IsInMenu()
        {
            bool menuOpen = memAPI.ReadByte(Game.MenuOpen) == Status.MenuOpen;
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
            bool inGame = memAPI.ReadByte(Game.Status) == Status.InGame;
            bool isAlucard = memAPI.ReadByte(Game.Character) == (int)Character.Alucard;
            bool notInPrologue = memAPI.ReadByte(Game.Area) != Various.Prologue;
            return (inGame && isAlucard && notInPrologue);
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

        public void ClearByte(long address)
        {
            memAPI.WriteByte(address, 0);
        }

        public string ReadSeedName()
        {
            return ReadString(Game.SeedStart);
        }

        public string ReadPresetName()
        {
            return ReadString(Game.PresetStart);
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
