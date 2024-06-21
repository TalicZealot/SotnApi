using BizHawk.Client.Common;
using SotnApi.Constants.Addresses.Alucard;
using SotnApi.Constants.Values.Alucard;
using SotnApi.Constants.Values.Alucard.Enums;
using SotnApi.Constants.Values.Game;
using SotnApi.Interfaces;
using System;
using Effects = SotnApi.Constants.Addresses.Alucard.Effects;

namespace SotnApi
{
    public sealed class AlucardApi : IAlucardApi
    {
        private readonly IMemoryApi memAPI;

        public AlucardApi(IMemoryApi? memAPI)
        {
            if (memAPI == null) throw new ArgumentNullException(nameof(memAPI));
            this.memAPI = memAPI;
        }

        public uint CurrentHp
        {
            get
            {
                return memAPI.ReadU32(Stats.CurrentHP);
            }
            set
            {
                memAPI.WriteU32(Stats.CurrentHP, value);
            }
        }
        public uint MaxtHp
        {
            get
            {
                return memAPI.ReadU32(Stats.MaxHP);
            }
            set
            {
                memAPI.WriteU32(Stats.MaxHP, value);
            }
        }
        public uint CurrentMp
        {
            get
            {
                return memAPI.ReadU32(Stats.CurrentMana);
            }
            set
            {
                memAPI.WriteU32(Stats.CurrentMana, value);
            }
        }
        public uint MaxtMp
        {
            get
            {
                return memAPI.ReadU32(Stats.MaxMana);
            }
            set
            {
                memAPI.WriteU32(Stats.MaxMana, value);
            }
        }
        public uint CurrentHearts
        {
            get
            {
                return memAPI.ReadU32(Stats.CurrentHearts);
            }
            set
            {
                memAPI.WriteU32(Stats.CurrentHearts, value);
            }
        }
        public uint MaxtHearts
        {
            get
            {
                return memAPI.ReadU32(Stats.MaxHearts);
            }
            set
            {
                memAPI.WriteU32(Stats.MaxHearts, value);
            }
        }
        public uint Str
        {
            get
            {
                return memAPI.ReadU32(Stats.Str);
            }
            set
            {
                memAPI.WriteU32(Stats.Str, value);
            }
        }
        public uint Con
        {
            get
            {
                return memAPI.ReadU32(Stats.Con);
            }
            set
            {
                memAPI.WriteU32(Stats.Con, value);
            }
        }
        public uint Int
        {
            get
            {
                return memAPI.ReadU32(Stats.Int);
            }
            set
            {
                memAPI.WriteU32(Stats.Int, value);
            }
        }
        public uint Lck
        {
            get
            {
                return memAPI.ReadU32(Stats.Lck);
            }
            set
            {
                memAPI.WriteU32(Stats.Lck, value);
            }
        }
        public uint Def
        {
            get
            {
                return memAPI.ReadU32(Stats.Def);
            }
        }
        public uint Gold
        {
            get
            {
                return memAPI.ReadU32(Stats.Gold);
            }
            set
            {
                memAPI.WriteU32(Stats.Gold, value);
            }
        }
        public uint Level
        {
            get
            {
                return memAPI.ReadU32(Stats.Level);
            }
            set
            {
                memAPI.WriteU32(Stats.Level, value);
            }
        }
        public uint Experiecne
        {
            get
            {
                return memAPI.ReadU32(Stats.Experience);
            }
            set
            {
                memAPI.WriteU32(Stats.Experience, value);
            }
        }
        public uint Rooms
        {
            get
            {
                return memAPI.ReadU32(Stats.Rooms);
            }
            set
            {
                memAPI.WriteU32(Stats.Rooms, value);
            }
        }
        public uint Kills
        {
            get
            {
                return memAPI.ReadU32(Stats.Kills);
            }
            set
            {
                memAPI.WriteU32(Stats.Kills, value);
            }
        }
        public uint WarpsFirstCastle
        {
            get
            {
                return memAPI.ReadByte(Stats.WarpsFirstCastle);
            }
            set
            {
                memAPI.WriteByte(Stats.WarpsFirstCastle, value);
            }
        }
        public uint WarpsSecondCastle
        {
            get
            {
                return memAPI.ReadByte(Stats.WarpsSecondCastle);
            }
            set
            {
                memAPI.WriteByte(Stats.WarpsSecondCastle, value);
            }
        }
        public bool WarpEntrance
        {
            get
            {
                var warps = memAPI.ReadByte(Stats.WarpsFirstCastle);
                if ((warps & (int)Warp.Entrance) == (int)Warp.Entrance)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                var warps = memAPI.ReadByte(Stats.WarpsFirstCastle);
                if (value)
                {
                    memAPI.WriteByte(Stats.WarpsFirstCastle, warps | (int)Warp.Entrance);
                }
                else
                {
                    uint invertedMask = (int)Warp.Entrance ^ 0xFF;
                    memAPI.WriteByte(Stats.WarpsFirstCastle, warps & invertedMask);
                }
            }
        }
        public bool WarpMines
        {
            get
            {
                var warps = memAPI.ReadByte(Stats.WarpsFirstCastle);
                if ((warps & (int)Warp.Mines) == (int)Warp.Mines)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                var warps = memAPI.ReadByte(Stats.WarpsFirstCastle);
                if (value)
                {
                    memAPI.WriteByte(Stats.WarpsFirstCastle, warps | (int)Warp.Mines);
                }
                else
                {
                    uint invertedMask = (int)Warp.Mines ^ 0xFF;
                    memAPI.WriteByte(Stats.WarpsFirstCastle, warps & invertedMask);
                }
            }
        }
        public bool WarpOuterWall
        {
            get
            {
                var warps = memAPI.ReadByte(Stats.WarpsFirstCastle);
                if ((warps & (int)Warp.OuterWall) == (int)Warp.OuterWall)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                var warps = memAPI.ReadByte(Stats.WarpsFirstCastle);
                if (value)
                {
                    memAPI.WriteByte(Stats.WarpsFirstCastle, warps | (int)Warp.OuterWall);
                }
                else
                {
                    uint invertedMask = (int)Warp.OuterWall ^ 0xFF;
                    memAPI.WriteByte(Stats.WarpsFirstCastle, warps & invertedMask);
                }
            }
        }
        public bool WarpKeep
        {
            get
            {
                var warps = memAPI.ReadByte(Stats.WarpsFirstCastle);
                if ((warps & (int)Warp.Keep) == (int)Warp.Keep)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                var warps = memAPI.ReadByte(Stats.WarpsFirstCastle);
                if (value)
                {
                    memAPI.WriteByte(Stats.WarpsFirstCastle, warps | (int)Warp.Keep);
                }
                else
                {
                    uint invertedMask = (int)Warp.Keep ^ 0xFF;
                    memAPI.WriteByte(Stats.WarpsFirstCastle, warps & invertedMask);
                }
            }
        }
        public bool WarpOlrox
        {
            get
            {
                var warps = memAPI.ReadByte(Stats.WarpsFirstCastle);
                if ((warps & (int)Warp.Olrox) == (int)Warp.Olrox)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                var warps = memAPI.ReadByte(Stats.WarpsFirstCastle);
                if (value)
                {
                    memAPI.WriteByte(Stats.WarpsFirstCastle, warps | (int)Warp.Olrox);
                }
                else
                {
                    uint invertedMask = (int)Warp.Olrox ^ 0xFF;
                    memAPI.WriteByte(Stats.WarpsFirstCastle, warps & invertedMask);
                }
            }
        }
        public bool WarpInvertedEntrance
        {
            get
            {
                var warps = memAPI.ReadByte(Stats.WarpsSecondCastle);
                if ((warps & (int)Warp.Entrance) == (int)Warp.Entrance)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                var warps = memAPI.ReadByte(Stats.WarpsSecondCastle);
                if (value)
                {
                    memAPI.WriteByte(Stats.WarpsSecondCastle, warps | (int)Warp.Entrance);
                }
                else
                {
                    uint invertedMask = (int)Warp.Entrance ^ 0xFF;
                    memAPI.WriteByte(Stats.WarpsSecondCastle, warps & invertedMask);
                }
            }
        }
        public bool WarpInvertedMines
        {
            get
            {
                var warps = memAPI.ReadByte(Stats.WarpsSecondCastle);
                if ((warps & (int)Warp.Mines) == (int)Warp.Mines)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                var warps = memAPI.ReadByte(Stats.WarpsSecondCastle);
                if (value)
                {
                    memAPI.WriteByte(Stats.WarpsSecondCastle, warps | (int)Warp.Mines);
                }
                else
                {
                    uint invertedMask = (int)Warp.Mines ^ 0xFF;
                    memAPI.WriteByte(Stats.WarpsSecondCastle, warps & invertedMask);
                }
            }
        }
        public bool WarpInvertedOuterWall
        {
            get
            {
                var warps = memAPI.ReadByte(Stats.WarpsSecondCastle);
                if ((warps & (int)Warp.OuterWall) == (int)Warp.OuterWall)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                var warps = memAPI.ReadByte(Stats.WarpsSecondCastle);
                if (value)
                {
                    memAPI.WriteByte(Stats.WarpsSecondCastle, warps | (int)Warp.OuterWall);
                }
                else
                {
                    uint invertedMask = (int)Warp.OuterWall ^ 0xFF;
                    memAPI.WriteByte(Stats.WarpsSecondCastle, warps & invertedMask);
                }
            }
        }
        public bool WarpInvertedKeep
        {
            get
            {
                var warps = memAPI.ReadByte(Stats.WarpsSecondCastle);
                if ((warps & (int)Warp.Keep) == (int)Warp.Keep)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                var warps = memAPI.ReadByte(Stats.WarpsSecondCastle);
                if (value)
                {
                    memAPI.WriteByte(Stats.WarpsSecondCastle, warps | (int)Warp.Keep);
                }
                else
                {
                    uint invertedMask = (int)Warp.Keep ^ 0xFF;
                    memAPI.WriteByte(Stats.WarpsSecondCastle, warps & invertedMask);
                }
            }
        }
        public bool WarpInvertedOlrox
        {
            get
            {
                var warps = memAPI.ReadByte(Stats.WarpsSecondCastle);
                if ((warps & (int)Warp.Olrox) == (int)Warp.Olrox)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                var warps = memAPI.ReadByte(Stats.WarpsSecondCastle);
                if (value)
                {
                    memAPI.WriteByte(Stats.WarpsSecondCastle, warps | (int)Warp.Olrox);
                }
                else
                {
                    uint invertedMask = (int)Warp.Olrox ^ 0xFF;
                    memAPI.WriteByte(Stats.WarpsSecondCastle, warps & invertedMask);
                }
            }
        }
        public bool OuterWallElevator
        {
            get
            {
                return memAPI.ReadByte(Shortcuts.OuterWallElevator) > 0;
            }
            set
            {
                memAPI.WriteByte(Shortcuts.OuterWallElevator, value ? 1u : 0u);
            }
        }
        public bool EntranceToMarble
        {
            get
            {
                return memAPI.ReadByte(Shortcuts.EntranceToMarble) > 0;
            }
            set
            {
                memAPI.WriteByte(Shortcuts.EntranceToMarble, value ? 1u : 0u);
            }
        }
        public bool AlchemyElevator
        {
            get
            {
                return memAPI.ReadByte(Shortcuts.AlchemyElevator) > 0;
            }
            set
            {
                memAPI.WriteByte(Shortcuts.AlchemyElevator, value ? 1u : 0u);
            }
        }
        public bool ChapelStatue
        {
            get
            {
                return memAPI.ReadByte(Shortcuts.ChapelStatue) > 0;
            }
            set
            {
                memAPI.WriteByte(Shortcuts.ChapelStatue, value ? 1u : 0u);
            }
        }
        public bool ColosseumElevator
        {
            get
            {
                return memAPI.ReadByte(Shortcuts.ColosseumElevator) > 0;
            }
            set
            {
                memAPI.WriteByte(Shortcuts.ColosseumElevator, value ? 1u : 0u);
            }
        }
        public bool ColosseumToChapel
        {
            get
            {
                return memAPI.ReadByte(Shortcuts.ColosseumToChapel) > 0;
            }
            set
            {
                memAPI.WriteByte(Shortcuts.ColosseumToChapel, value ? 1u : 0u);
            }
        }
        public bool MarbleBlueDoor
        {
            get
            {
                return memAPI.ReadByte(Shortcuts.MarbleBlueDoor) > 0;
            }
            set
            {
                memAPI.WriteByte(Shortcuts.MarbleBlueDoor, value ? 1u : 0u);
            }
        }
        public bool CavernsSwitchAndBridge
        {
            get
            {
                return memAPI.ReadByte(Shortcuts.CavernsSwitchAndBridge) == 3;
            }
            set
            {
                memAPI.WriteByte(Shortcuts.CavernsSwitchAndBridge, value ? 3u : 0u);
            }
        }
        public bool EntranceToCaverns
        {
            get
            {
                return memAPI.ReadByte(Shortcuts.EntranceToCaverns) > 0;
            }
            set
            {
                memAPI.WriteByte(Shortcuts.EntranceToCaverns, value ? 1u : 0u);
            }
        }
        public bool EntranceWarp
        {
            get
            {
                return memAPI.ReadByte(Shortcuts.EntranceWarp) > 0;
            }
            set
            {
                memAPI.WriteByte(Shortcuts.EntranceWarp, value ? 1u : 0u);
            }
        }
        public bool FirstClockRoomDoor
        {
            get
            {
                return memAPI.ReadByte(Shortcuts.FirstClockRoomDoor) > 0;
            }
            set
            {
                memAPI.WriteByte(Shortcuts.FirstClockRoomDoor, value ? 1u : 0u);
            }
        }
        public bool SecondClockRoomDoor
        {
            get
            {
                return memAPI.ReadByte(Shortcuts.SecondClockRoomDoor) > 0;
            }
            set
            {
                memAPI.WriteByte(Shortcuts.SecondClockRoomDoor, value ? 1u : 0u);
            }
        }
        public bool FirstDemonButton
        {
            get
            {
                return memAPI.ReadByte(Shortcuts.FirstDemonButton) > 0;
            }
            set
            {
                memAPI.WriteByte(Shortcuts.FirstDemonButton, value ? 1u : 0u);
            }
        }
        public bool SecondDemonButton
        {
            get
            {
                return memAPI.ReadByte(Shortcuts.SecondDemonButton) > 0;
            }
            set
            {
                memAPI.WriteByte(Shortcuts.SecondDemonButton, value ? 1u : 0u);
            }
        }
        public bool KeepStairs
        {
            get
            {
                return memAPI.ReadByte(Shortcuts.KeepStairs) > 0;
            }
            set
            {
                memAPI.WriteByte(Shortcuts.KeepStairs, value ? 1u : 0u);
            }
        }
        public uint WingsmashHorizontalSpeed
        {
            get
            {
                return memAPI.ReadByte(Speeds.WingsmashHorizontal);
            }
            set
            {
                memAPI.WriteByte(Speeds.WingsmashHorizontal, value);
            }
        }
        public uint WalkingWholeSpeed
        {
            get
            {
                return memAPI.ReadByte(Speeds.WalkingWhole);
            }
            set
            {
                memAPI.WriteByte(Speeds.WalkingWhole, value);
            }
        }
        public uint WalkingFractSpeed
        {
            get
            {
                return memAPI.ReadByte(Speeds.WalkingFract);
            }
            set
            {
                memAPI.WriteByte(Speeds.WalkingFract, value);
            }
        }
        public int BackdashWholeSpeed
        {
            get
            {
                return memAPI.ReadS16(Speeds.BackdashWhole);
            }
            set
            {
                memAPI.WriteS16(Speeds.BackdashWhole, value);
            }
        }
        public uint JumpingHorizontalWholeSpeed
        {
            get
            {
                return memAPI.ReadByte(Speeds.JumpingHorizontalWhole);
            }
            set
            {
                memAPI.WriteByte(Speeds.JumpingHorizontalWhole, value);
            }
        }
        public uint JumpingHorizontalFractSpeed
        {
            get
            {
                return memAPI.ReadByte(Speeds.JumpingHorizontalFract);
            }
            set
            {
                memAPI.WriteByte(Speeds.JumpingHorizontalFract, value);
            }
        }
        public uint JumpingAttackLeftHorizontalWholeSpeed
        {
            get
            {
                return memAPI.ReadByte(Speeds.JumpingAttackLeftHorizontalWhole);
            }
            set
            {
                memAPI.WriteByte(Speeds.JumpingAttackLeftHorizontalWhole, value);
            }
        }
        public uint JumpingAttackLeftHorizontalFractSpeed
        {
            get
            {
                return memAPI.ReadByte(Speeds.JumpingAttackLeftHorizontalFract);
            }
            set
            {
                memAPI.WriteByte(Speeds.JumpingAttackLeftHorizontalFract, value);
            }
        }
        public uint JumpingAttackRightHorizontalWholeSpeed
        {
            get
            {
                return memAPI.ReadByte(Speeds.JumpingAttackRightHorizontalWhole);
            }
            set
            {
                memAPI.WriteByte(Speeds.JumpingAttackRightHorizontalWhole, value);
            }
        }
        public uint JumpingAttackRightHorizontalFractSpeed
        {
            get
            {
                return memAPI.ReadByte(Speeds.JumpingAttackRightHorizontalFract);
            }
            set
            {
                memAPI.WriteByte(Speeds.JumpingAttackRightHorizontalFract, value);
            }
        }
        public uint FallingHorizontalWholeSpeed
        {
            get
            {
                return memAPI.ReadByte(Speeds.FallingHorizontalWhole);
            }
            set
            {
                memAPI.WriteByte(Speeds.FallingHorizontalWhole, value);
            }
        }
        public uint FallingHorizontalFractSpeed
        {
            get
            {
                return memAPI.ReadByte(Speeds.FallingHorizontalFract);
            }
            set
            {
                memAPI.WriteByte(Speeds.FallingHorizontalFract, value);
            }
        }
        public sbyte WolfDashTopRightSpeed
        {
            get
            {
                return (sbyte)memAPI.ReadByte(Speeds.WolfDashTopRight);
            }
            set
            {
                memAPI.WriteByte(Speeds.WolfDashTopRight, (uint)value);
            }
        }
        public sbyte WolfDashTopLeftSpeed
        {
            get
            {
                return (sbyte)memAPI.ReadByte(Speeds.WolfDashTopLeft);
            }
            set
            {
                memAPI.WriteByte(Speeds.WolfDashTopLeft, (uint)value);
            }
        }
        public uint BackdashDecel
        {
            get
            {
                return memAPI.ReadByte(Speeds.BackdashDecel);
            }
            set
            {
                memAPI.WriteByte(Speeds.BackdashDecel, value);
            }
        }
        public uint RightHand
        {
            get
            {
                return memAPI.ReadByte(Inventory.RightHandSlot);
            }
            set
            {
                memAPI.WriteByte(Inventory.RightHandSlot, value);
            }
        }
        public uint LeftHand
        {
            get
            {
                return memAPI.ReadByte(Inventory.LeftHandSlot);
            }
            set
            {
                memAPI.WriteByte(Inventory.LeftHandSlot, value);
            }
        }
        public uint Armor
        {
            get
            {
                return memAPI.ReadByte(Inventory.ArmorSlot);
            }
            set
            {
                memAPI.WriteByte(Inventory.ArmorSlot, value);
            }
        }
        public uint Helm
        {
            get
            {
                return memAPI.ReadByte(Inventory.HelmSlot);
            }
            set
            {
                memAPI.WriteByte(Inventory.HelmSlot, value);
            }
        }
        public uint Cloak
        {
            get
            {
                return memAPI.ReadByte(Inventory.CloakSlot);
            }
            set
            {
                memAPI.WriteByte(Inventory.CloakSlot, value);
            }
        }
        public uint Accessory1
        {
            get
            {
                return memAPI.ReadByte(Inventory.AccessorySlot1);
            }
            set
            {
                memAPI.WriteByte(Inventory.AccessorySlot1, value);
            }
        }
        public uint Accessory2
        {
            get
            {
                return memAPI.ReadByte(Inventory.AccessorySlot2);
            }
            set
            {
                memAPI.WriteByte(Inventory.AccessorySlot2, value);
            }
        }
        public uint HandCursor
        {
            get
            {
                return memAPI.ReadByte(Inventory.HandCursor);
            }
            set
            {
                memAPI.WriteByte(Inventory.HandCursor, value);
            }
        }
        public uint HelmCursor
        {
            get
            {
                return memAPI.ReadByte(Inventory.HelmCursor);
            }
            set
            {
                memAPI.WriteByte(Inventory.HelmCursor, value);
            }
        }
        public uint ArmorCursor
        {
            get
            {
                return memAPI.ReadByte(Inventory.ArmorCursor);
            }
            set
            {
                memAPI.WriteByte(Inventory.ArmorCursor, value);
            }
        }
        public uint CloakCursor
        {
            get
            {
                return memAPI.ReadByte(Inventory.CloakCursor);
            }
            set
            {
                memAPI.WriteByte(Inventory.CloakCursor, value);
            }
        }
        public uint AccessoryCursor
        {
            get
            {
                return memAPI.ReadByte(Inventory.AccessoryCursor);
            }
            set
            {
                memAPI.WriteByte(Inventory.AccessoryCursor, value);
            }
        }
        public Subweapon Subweapon
        {
            get
            {
                return (Subweapon)memAPI.ReadByte(Inventory.Subweapon);
            }
            set
            {
                memAPI.WriteByte(Inventory.Subweapon, (uint)value);
            }
        }
        public int HorizontalVelocityWhole
        {
            get
            {
                return memAPI.ReadS16(Entity.HorizontalVelocityWhole);
            }
            set
            {
                memAPI.WriteS16(Entity.HorizontalVelocityWhole, value);
            }
        }
        public uint HorizontalVelocityFractional
        {
            get
            {
                return memAPI.ReadByte(Entity.HorizontalVelocityFract);
            }
            set
            {
                memAPI.WriteByte(Entity.HorizontalVelocityFract, value);
            }
        }
        public uint State
        {
            get
            {
                return memAPI.ReadByte(Stats.State);
            }
            set
            {
                memAPI.WriteByte(Stats.State, value);
            }
        }
        public uint Action
        {
            get
            {
                return memAPI.ReadByte(Stats.Action);
            }
            set
            {
                memAPI.WriteByte(Stats.Action, value);
            }
        }
        public double ScreenX
        {
            get
            {
                uint rawValue = memAPI.ReadU32(Stats.ScreenX);
                return ((int)rawValue / 65536.0);
            }
        }
        public double ScreenY
        {
            get
            {
                uint rawValue = memAPI.ReadU32(Stats.ScreenY);
                return ((int)rawValue / 65536.0);
            }
        }
        public uint MapX
        {
            get
            {
                return memAPI.ReadByte(Stats.MapX) + memAPI.ReadByte(Stats.MapOffsetX);
            }
        }
        public uint MapY
        {
            get
            {
                return memAPI.ReadByte(Stats.MapY) + memAPI.ReadByte(Stats.MapOffsetY);
            }
        }
        public bool FacingLeft
        {
            get
            {
                return memAPI.ReadByte(Stats.Facing) > 0;
            }
            set
            {
                if (value)
                {
                    memAPI.WriteByte(Stats.Facing, 1);
                }
                else
                {
                    memAPI.WriteByte(Stats.Facing, 0);
                }
            }
        }
        public uint DarkMetamorphasisTimer
        {
            get
            {
                return memAPI.ReadByte(Timers.DarkMetamorphasis);
            }
            set
            {
                memAPI.WriteByte(Timers.DarkMetamorphasis, value);
            }
        }
        public uint AttackPotionTimer
        {
            get
            {
                return memAPI.ReadByte(Timers.AttackPotion);
            }
            set
            {
                memAPI.WriteByte(Timers.AttackPotion, value);
            }
        }
        public uint DefencePotionTimer
        {
            get
            {
                return memAPI.ReadByte(Timers.DefencePotion);
            }
            set
            {
                memAPI.WriteByte(Timers.DefencePotion, value);
            }
        }
        public uint InvincibilityTimer
        {
            get
            {
                return memAPI.ReadByte(Timers.Invincibility);
            }
            set
            {
                memAPI.WriteByte(Timers.Invincibility, value);
            }
        }
        public uint PotionInvincibilityTimer
        {
            get
            {
                return memAPI.ReadByte(Timers.PotionInvincibility);
            }
            set
            {
                memAPI.WriteByte(Timers.PotionInvincibility, value);
            }
        }
        public uint KnockbackInvincibilityTimer
        {
            get
            {
                return memAPI.ReadByte(Timers.KnockbackInvincibility);
            }
            set
            {
                memAPI.WriteByte(Timers.KnockbackInvincibility, value);
            }
        }
        public uint FreezeInvincibilityTimer
        {
            get
            {
                return memAPI.ReadByte(Timers.FreezeInvincibility);
            }
            set
            {
                memAPI.WriteByte(Timers.FreezeInvincibility, value);
            }
        }
        public uint SubweaponTimer
        {
            get
            {
                return memAPI.ReadByte(Timers.SubweaponTimer);
            }
            set
            {
                memAPI.WriteByte(Timers.SubweaponTimer, value);
            }
        }
        public uint ShineTimer
        {
            get
            {
                return memAPI.ReadByte(Timers.Shine);
            }
            set
            {
                memAPI.WriteByte(Timers.Shine, value);
            }
        }
        public uint CurseTimer
        {
            get
            {
                return memAPI.ReadU16(Timers.Curse);
            }
            set
            {
                memAPI.WriteU16(Timers.Curse, value);
            }
        }
        public uint PoisonTimer
        {
            get
            {
                return memAPI.ReadU16(Timers.Poison);
            }
            set
            {
                memAPI.WriteU16(Timers.Poison, value);
            }
        }
        public uint StunTimer
        {
            get
            {
                return memAPI.ReadU16(Timers.Stun);
            }
            set
            {
                memAPI.WriteU16(Timers.Stun, value);
            }
        }
        public uint ContactDamage
        {
            get
            {
                return memAPI.ReadU16(Stats.ContactDamage);
            }
            set
            {
                memAPI.WriteU16(Stats.ContactDamage, value);
            }
        }

        public int GetSelectedItem()
        {
            uint category = memAPI.ReadByte(Inventory.Category);
            uint cursor;
            int itemIndex = 0;
            switch (category)
            {
                case 0:
                case 1:
                    cursor = memAPI.ReadByte(Inventory.HandCursor);
                    itemIndex = (int)memAPI.ReadByte(Inventory.HandInventoryStart + cursor);
                    break;
                case 2:
                    cursor = memAPI.ReadByte(Inventory.HelmCursor);
                    itemIndex = (int)memAPI.ReadByte(Inventory.HelmInventoryStart + cursor - 1) + Equipment.HandCount + 1;
                    break;
                case 3:
                    cursor = memAPI.ReadByte(Inventory.ArmorCursor);
                    itemIndex = (int)memAPI.ReadByte(Inventory.ArmorInventoryStart + cursor - 1) + Equipment.HandCount + 1;
                    break;
                case 4:
                    cursor = memAPI.ReadByte(Inventory.CloakCursor);
                    itemIndex = (int)memAPI.ReadByte(Inventory.CloakInventoryStart + cursor - 1) + Equipment.HandCount + 1;
                    break;
                case 5:
                case 6:
                    cursor = memAPI.ReadByte(Inventory.AccessoryCursor);
                    itemIndex = (int)memAPI.ReadByte(Inventory.AccessoryInventoryStart + cursor - 1) + Equipment.HandCount + 1;
                    break;
                default:
                    break;
            }
            for (int i = 0; i < Equipment.CategoryHeaders.Length; i++)
            {
                if (itemIndex == Equipment.CategoryHeaders[i])
                {
                    return -1;
                }
            }
            return itemIndex;
        }

        public Relic GetSelectedRelic()
        {
            uint cursor = memAPI.ReadByte(Inventory.RelicCursor);
            if (cursor > 22)
            {
                cursor += 2;
            }
            return (Relic)cursor;
        }

        public bool HasRelic(Relic relic)
        {
            return memAPI.ReadByte(Relics.AllRelics[relic.ToString()]) > 0;
        }

        public void TakeRelic(Relic relic)
        {
            memAPI.WriteByte(Relics.AllRelics[relic.ToString()], 0);
        }

        public void GrantRelic(Relic relic, bool allowSpawn = false)
        {
            uint relicOn = 3;
            uint relicOff = 1;
            uint value = 0;
            if (allowSpawn)
            {
                relicOn = 6;
                relicOff = 5;
            }
            if (relic >= Relic.BatCard && relic <= Relic.NoseDevilCard)
            {
                value = relicOff;
            }
            else
            {
                value = relicOn;
            }
            memAPI.WriteByte(Relics.AllRelics[relic.ToString()], value);
        }

        public void GrantFirstCastleWarp(Warp warp)
        {
            memAPI.WriteByte(Stats.WarpsFirstCastle, WarpsFirstCastle | (uint)warp);
        }

        public void GrantSecondCastleWarp(Warp warp)
        {
            memAPI.WriteByte(Stats.WarpsSecondCastle, WarpsSecondCastle | (uint)warp);
        }

        public bool HasItemInInventory(int item)
        {
            if (item == -1) throw new ArgumentException("Invalid item!");

            uint value = memAPI.ReadByte(Inventory.HandQuantityStart + item);
            return value > 0;
        }

        public void GrantItemByName(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            int item = Equipment.Items.IndexOf(name);
            if (item == -1) throw new ArgumentException("Invalid item name!");

            uint itemCount = memAPI.ReadByte(Inventory.HandQuantityStart + item);
            memAPI.WriteByte(Inventory.HandQuantityStart + item, itemCount + 1);
            if (itemCount == 0)
            {
                SortItemInventory((uint)item);
            }
        }

        public void TakeOneItem(int item)
        {
            if (item < 0) throw new ArgumentException("Invalid item index!");
            uint itemCount = memAPI.ReadByte(Inventory.HandQuantityStart + item);
            if (itemCount == 0)
            {
                return;
            }
            memAPI.WriteByte(Inventory.HandQuantityStart + item, itemCount - 1);
        }

        public bool IsInvincible()
        {
            return memAPI.ReadU16(Timers.Invincibility) > 0 || memAPI.ReadByte(Timers.KnockbackInvincibility) > 0 || memAPI.ReadByte(Timers.PotionInvincibility) > 0 || memAPI.ReadByte(Timers.FreezeInvincibility) > 0;
        }

        public bool HasControl()
        {

            return memAPI.ReadByte(Stats.HasControl) == 0;
        }

        public bool HasHitbox()
        {
            return memAPI.ReadByte(Entity.Address + Entities.HitboxWidth) > 0 && memAPI.ReadByte(Entity.Address + Entities.HitboxHeight) > 0;
        }

        public void Heal(uint amount)
        {
            memAPI.WriteS16(Effects.HealAmount, (int)amount);
            memAPI.WriteByte(Effects.HealTrigger, 1);
        }

        public void InstantDeath()
        {
            memAPI.WriteS16(Constants.Addresses.Alucard.Entity.Step, 0x10);
            memAPI.WriteS16(Constants.Addresses.Alucard.Entity.Step2, 0);
        }

        public void ActivateStopwatch()
        {
            memAPI.WriteByte(Effects.Activator, SotnApi.Constants.Values.Alucard.Effects.Stopwatch);
        }

        public void ForceLibraryCard()
        {
            memAPI.WriteByte(Effects.Activator, SotnApi.Constants.Values.Alucard.Effects.LibraryCard);
        }

        public bool EffectActive()
        {
            return memAPI.ReadByte(Effects.Activator) > 0;
        }

        public void ActivatePotion(Potion potion)
        {
            memAPI.WriteByte(Effects.Activator, SotnApi.Constants.Values.Alucard.Effects.Potion);
            memAPI.WriteByte(Effects.ActivatorIndex, (uint)potion);
        }

        public void ClearInventory()
        {
            for (int i = 0; i < Equipment.Items.Count; i++)
            {
                if (ViableItem(i))
                {
                    memAPI.WriteByte(Inventory.HandQuantityStart + i, 0);
                }
            }
        }

        private void SortItemInventory(uint item)
        {
            int countsBase = Equipment.HandCount + 1;
            long slotBaseAddress;
            int max;
            if (item <= Equipment.HandCount)
            {
                max = Equipment.HandCount;
                slotBaseAddress = Inventory.HandInventoryStart;
                countsBase = 0;
            }
            else if (item > Equipment.HandCount && item <= 1 + Equipment.HandCount + Equipment.ArmorCount - 1)
            {
                max = Equipment.ArmorCount;
                slotBaseAddress = Inventory.ArmorInventoryStart;
            }
            else if (item > Equipment.HandCount + Equipment.ArmorCount - 1 && item <= 2 + Equipment.HandCount + Equipment.ArmorCount - 1 + Equipment.HelmCount)
            {
                max = Equipment.HelmCount;
                slotBaseAddress = Inventory.HelmInventoryStart;
            }
            else if (item > Equipment.HandCount + Equipment.ArmorCount - 1 + Equipment.HelmCount && item <= 3 + Equipment.HandCount + Equipment.ArmorCount - 1 + Equipment.HelmCount + Equipment.CloakCount)
            {
                max = Equipment.CloakCount;
                slotBaseAddress = Inventory.CloakInventoryStart;
            }
            else if (item > Equipment.HandCount + Equipment.ArmorCount - 1 + Equipment.HelmCount + Equipment.CloakCount && item <= 4 + Equipment.HandCount + Equipment.ArmorCount - 1 + Equipment.HelmCount + Equipment.CloakCount + Equipment.AccessoryCount)
            {
                max = Equipment.AccessoryCount;
                slotBaseAddress = Inventory.AccessoryInventoryStart;
            }
            else
            {
                max = Equipment.ArmorCount;
                slotBaseAddress = Inventory.ArmorInventoryStart;
            }

            for (int i = 0; i < max; i++)
            {
                uint slotValue = memAPI.ReadByte(slotBaseAddress + i);
                uint slotItemCount = memAPI.ReadByte(Inventory.HandQuantityStart + slotValue + countsBase);
                if (slotItemCount == 0)
                {
                    long itemSlot = FindItemInventorySlot(slotBaseAddress, max, item - countsBase);
                    if (itemSlot == 0)
                    {
                        break;
                    }
                    memAPI.WriteByte(slotBaseAddress + i, (uint)(item - countsBase));
                    memAPI.WriteByte(itemSlot, slotValue);
                    break;
                }
            }
        }

        private long FindItemInventorySlot(long slotBaseAddress, int max, long item)
        {
            for (int j = 0; j <= max; j++)
            {
                uint slotValue = memAPI.ReadByte(slotBaseAddress + j);
                if (slotValue == item)
                {
                    return slotBaseAddress + j;
                }
            }
            Console.WriteLine($"Item slot for index {item} not found in the inventory category starting at {slotBaseAddress:X} and ending at {max}th slot.");
            return 0;
        }

        private bool ViableItem(int i)
        {
            return Equipment.Items[i] != "empty hand" && Equipment.Items[i] != "----helm" && Equipment.Items[i] != "----armor"
                                && Equipment.Items[i] != "----cloak" && Equipment.Items[i] != "----accessory";
        }
    }
}
