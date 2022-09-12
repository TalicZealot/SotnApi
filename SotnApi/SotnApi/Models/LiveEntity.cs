using BizHawk.Client.Common;
using SotnApi.Constants.Values.Game;
using System;

namespace SotnApi.Models
{
    /// <summary>
    /// A live entity object rendered in-game. Enemies, projectiles, items, hitboxes, interactable objects.
    /// </summary>
    public sealed class LiveEntity
    {
        private readonly IMemoryApi memAPI;

        public LiveEntity(long address, IMemoryApi? memAPI)
        {
            Address = address;
            if (memAPI == null) { throw new ArgumentNullException("Memory API is null"); }
            this.memAPI = memAPI;
        }

        public long Address { get; set; }

        public uint Xpos
        {
            get
            {
                return memAPI.ReadU16(Address + Entities.XposOffset);
            }
            set
            {
                memAPI.WriteU16(Address + Entities.XposOffset, value);
            }
        }

        public uint Ypos
        {
            get
            {
                return memAPI.ReadU16(Address + Entities.YposOffset);
            }
            set
            {
                memAPI.WriteU16(Address + Entities.YposOffset, value);
            }
        }

        public uint SpeedHorizontalFract
        {
            get
            {
                return memAPI.ReadU16(Address + Entities.SpeedFractOffset);
            }
            set
            {
                memAPI.WriteU16(Address + Entities.SpeedFractOffset, value);
            }
        }

        public int SpeedHorizontal
        {
            get
            {
                return (int)memAPI.ReadS16(Address + Entities.SpeedWholeOffset);
            }
            set
            {
                memAPI.WriteS16(Address + Entities.SpeedWholeOffset, value);
            }
        }

        public uint SpeedVerticalFract
        {
            get
            {
                return memAPI.ReadByte(Address + Entities.SpeedVerticalFractOffset);
            }
            set
            {
                memAPI.WriteByte(Address + Entities.SpeedVerticalFractOffset, value);
            }
        }

        public int SpeedVertical
        {
            get
            {
                return (int)(sbyte)memAPI.ReadByte(Address + Entities.SpeedVerticalWholeOffset);
            }
            set
            {
                if (value < 0)
                {
                    memAPI.WriteByte(Address + Entities.SpeedVerticalNegativeOffset, 0xFF);
                }
                memAPI.WriteByte(Address + Entities.SpeedVerticalWholeOffset, (byte)(sbyte)value);
            }
        }

        public uint AutoToggle
        {
            get
            {
                return memAPI.ReadByte(Address + Entities.HitboxAutoToggleOffset);
            }
            set
            {
                memAPI.WriteByte(Address + Entities.HitboxAutoToggleOffset, value);
            }
        }

        public int Hp
        {
            get
            {
                return memAPI.ReadS16(Address + Entities.HpOffset);
            }
            set
            {
                memAPI.WriteS16(Address + Entities.HpOffset, value);
            }
        }

        public uint Def
        {
            get
            {
                return memAPI.ReadByte(Address + Entities.DefOffset);
            }
            set
            {
                memAPI.WriteByte(Address + Entities.DefOffset, value);
            }
        }

        public uint Damage
        {
            get
            {
                return memAPI.ReadU16(Address + Entities.DamageOffset);
            }
            set
            {
                memAPI.WriteU16(Address + Entities.DamageOffset, value);
            }
        }

        public uint DamageTypeA
        {
            get
            {
                return memAPI.ReadByte(Address + Entities.DamageTypeAOffset);
            }
            set
            {
                memAPI.WriteByte(Address + Entities.DamageTypeAOffset, value);
            }
        }

        public uint DamageTypeB
        {
            get
            {
                return memAPI.ReadByte(Address + Entities.DamageTypeBOffset);
            }
            set
            {
                memAPI.WriteByte(Address + Entities.DamageTypeBOffset, value);
            }
        }

        public uint Palette
        {
            get
            {
                return memAPI.ReadByte(Address + Entities.PaletteOffset);
            }
            set
            {
                memAPI.WriteByte(Address + Entities.PaletteOffset, value);
            }
        }

        public uint ColorMode
        {
            get
            {
                return memAPI.ReadByte(Address + Entities.ColorModeOffset);
            }
            set
            {
                memAPI.WriteByte(Address + Entities.ColorModeOffset, value);
            }
        }

        public uint AiId
        {
            get
            {
                return memAPI.ReadU16(Address + Entities.AiIdOffset);
            }
            set
            {
                memAPI.WriteU16(Address + Entities.AiIdOffset, value);
            }
        }

        public uint LockOn
        {
            get
            {
                return memAPI.ReadU16(Address + Entities.LockOnOffset);
            }
            set
            {
                memAPI.WriteU16(Address + Entities.LockOnOffset, value);
            }
        }

        public uint HitboxWidth
        {
            get
            {
                return memAPI.ReadByte(Address + Entities.HitboxWidthOffset);
            }
            set
            {
                memAPI.WriteByte(Address + Entities.HitboxWidthOffset, value);
            }
        }

        public uint HitboxHeight
        {
            get
            {
                return memAPI.ReadByte(Address + Entities.HitboxHeightOffset);
            }
            set
            {
                memAPI.WriteByte(Address + Entities.HitboxHeightOffset, value);
            }
        }

        public uint InvincibilityFrames
        {
            get
            {
                return memAPI.ReadByte(Address + Entities.InvincibilityFramesOffset);
            }
            set
            {
                memAPI.WriteByte(Address + Entities.InvincibilityFramesOffset, value);
            }
        }
    }
}
