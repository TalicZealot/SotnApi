using BizHawk.Client.Common;
using SotnApi.Constants.Values.Game;
using System;
using System.Collections.Generic;

namespace SotnApi.Models
{
    /// <summary>
    /// A live entity object rendered in-game. Enemies, projectiles, items, hitboxes, interactable objects.
    /// </summary>
    public class LiveActor
    {
        private readonly IMemoryApi memAPI;

        public LiveActor(long address, IMemoryApi? memAPI)
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
                return memAPI.ReadU16(Address + Actors.XposOffset);
            }
            set
            {
                memAPI.WriteU16(Address + Actors.XposOffset, value);
            }
        }

        public uint Ypos
        {
            get
            {
                return memAPI.ReadU16(Address + Actors.YposOffset);
            }
            set
            {
                memAPI.WriteU16(Address + Actors.YposOffset, value);
            }
        }

        public uint AutoToggle
        {
            get
            {
                return memAPI.ReadByte(Address + Actors.HitboxAutoToggleOffset);
            }
            set
            {
                memAPI.WriteByte(Address + Actors.HitboxAutoToggleOffset, value);
            }
        }

        public uint Hp
        {
            get
            {
                return memAPI.ReadU16(Address + Actors.HpOffset);
            }
            set
            {
                memAPI.WriteU16(Address + Actors.HpOffset, value);
            }
        }

        public uint Def
        {
            get
            {
                return memAPI.ReadByte(Address + Actors.DefOffset);
            }
            set
            {
                memAPI.WriteByte(Address + Actors.DefOffset, value);
            }
        }

        public uint Damage
        {
            get
            {
                return memAPI.ReadU16(Address + Actors.DamageOffset);
            }
            set
            {
                memAPI.WriteU16(Address + Actors.DamageOffset, value);
            }
        }

        public uint DamageTypeA
        {
            get
            {
                return memAPI.ReadByte(Address + Actors.DamageTypeAOffset);
            }
            set
            {
                memAPI.WriteByte(Address + Actors.DamageTypeAOffset, value);
            }
        }

        public uint DamageTypeB
        {
            get
            {
                return memAPI.ReadByte(Address + Actors.DamageTypeBOffset);
            }
            set
            {
                memAPI.WriteByte(Address + Actors.DamageTypeBOffset, value);
            }
        }

        public uint Palette
        {
            get
            {
                return memAPI.ReadByte(Address + Actors.PaletteOffset);
            }
            set
            {
                memAPI.WriteByte(Address + Actors.PaletteOffset, value);
            }
        }

        public uint ColorMode
        {
            get
            {
                return memAPI.ReadByte(Address + Actors.ColorModeOffset);
            }
            set
            {
                memAPI.WriteByte(Address + Actors.ColorModeOffset, value);
            }
        }
        public uint Sprite
        {
            get
            {
                return memAPI.ReadU16(Address + Actors.SpriteOffset);
            }
            set
            {
                memAPI.WriteU16(Address + Actors.SpriteOffset, value);
            }
        }

        public uint HitboxWidth
        {
            get
            {
                return memAPI.ReadByte(Address + Actors.HitboxWidthOffset);
            }
            set
            {
                memAPI.WriteByte(Address + Actors.HitboxWidthOffset, value);
            }
        }

        public uint HitboxHeight
        {
            get
            {
                return memAPI.ReadByte(Address + Actors.HitboxHeightOffset);
            }
            set
            {
                memAPI.WriteByte(Address + Actors.HitboxHeightOffset, value);
            }
        }
    }
}
