using SotnApi.Constants.Values.Game;
using System;
using System.Collections.Generic;

namespace SotnApi.Models
{
    /// <summary>
    /// An entity object that can be rendered in-game. Enemies, projectiles, items, hitboxes, interactable objects.
    /// </summary>
    public class Entity
    {
        public Entity(List<byte>? entity = null)
        {
            if (entity != null)
            {
                this.Value = entity;
            }
            else
            {
                Value = new List<byte>();
                for (int i = 0; i <= Entities.Size; i++)
                {
                    Value.Add(0);
                }
            }
        }
        public List<byte> Value { get; set; }

        public ushort Xpos
        {
            get
            {
                return BitConverter.ToUInt16(Value.ToArray(), Entities.XposOffset);
            }
            set
            {
                byte[] valueBytes = BitConverter.GetBytes(value);
                for (int i = 0; i < 2; i++)
                {
                    Value[Entities.XposOffset + i] = valueBytes[i];
                }
            }
        }

        public ushort Ypos
        {
            get
            {
                return BitConverter.ToUInt16(Value.ToArray(), Entities.YposOffset);
            }
            set
            {
                byte[] valueBytes = BitConverter.GetBytes(value);
                for (int i = 0; i < 2; i++)
                {
                    Value[Entities.YposOffset + i] = valueBytes[i];
                }
            }
        }

        public ushort SpeedHorizontalFract
        {
            get
            {
                return BitConverter.ToUInt16(Value.ToArray(), Entities.SpeedFractOffset);
            }
            set
            {
                byte[] valueBytes = BitConverter.GetBytes(value);
                for (int i = 0; i < 2; i++)
                {
                    Value[Entities.SpeedFractOffset + i] = valueBytes[i];
                }
            }
        }

        public ushort SpeedHorizontal
        {
            get
            {
                return BitConverter.ToUInt16(Value.ToArray(), Entities.SpeedWholeOffset);
            }
            set
            {
                byte[] valueBytes = BitConverter.GetBytes(value);
                for (int i = 0; i < 2; i++)
                {
                    Value[Entities.SpeedWholeOffset + i] = valueBytes[i];
                }
            }
        }

        public ushort SpeedVerticalFract
        {
            get
            {
                return Value[Entities.SpeedVerticalFractOffset];
            }
            set
            {
                Value[Entities.SpeedVerticalFractOffset] = (byte)value;
            }
        }

        public ushort SpeedVertical
        {
            get
            {
                return Value[Entities.SpeedVerticalWholeOffset];
            }
            set
            {
                Value[Entities.SpeedVerticalWholeOffset] = (byte)value;
            }
        }

        public ushort AutoToggle
        {
            get
            {
                return Value[Entities.HitboxAutoToggleOffset];
            }
            set
            {
                Value[Entities.HitboxAutoToggleOffset] = (byte)value;
            }
        }

        public ushort Hp
        {
            get
            {
                return BitConverter.ToUInt16(Value.ToArray(), Entities.HpOffset);
            }
            set
            {
                byte[] valueBytes = BitConverter.GetBytes(value);
                for (int i = 0; i < 2; i++)
                {
                    Value[Entities.HpOffset + i] = valueBytes[i];
                }
            }
        }

        public ushort Def
        {
            get
            {
                return BitConverter.ToUInt16(Value.ToArray(), Entities.DefOffset);
            }
            set
            {
                byte[] valueBytes = BitConverter.GetBytes(value);
                for (int i = 0; i < 2; i++)
                {
                    Value[Entities.DefOffset + i] = valueBytes[i];
                }
            }
        }

        public ushort Damage
        {
            get
            {
                return BitConverter.ToUInt16(Value.ToArray(), Entities.DamageOffset);
            }
            set
            {
                byte[] valueBytes = BitConverter.GetBytes(value);
                for (int i = 0; i < 2; i++)
                {
                    Value[Entities.DamageOffset + i] = valueBytes[i];
                }
            }
        }

        public uint DamageTypeA
        {
            get
            {
                return Value[Entities.DamageTypeAOffset];
            }
            set
            {
                Value[Entities.DamageTypeAOffset] = (byte)value;
            }
        }

        public uint DamageTypeB
        {
            get
            {
                return Value[Entities.DamageTypeBOffset];
            }
            set
            {
                Value[Entities.DamageTypeBOffset] = (byte)value;
            }
        }

        public ushort Palette
        {
            get
            {
                return Value[Entities.PaletteOffset];
            }
            set
            {
                Value[Entities.PaletteOffset] = (byte)value;
            }
        }

        public ushort ColorMode
        {
            get
            {
                return Value[Entities.ColorModeOffset];
            }
            set
            {
                Value[Entities.ColorModeOffset] = (byte)value;
            }
        }
        //AI id
        public ushort AiId
        {
            get
            {
                return BitConverter.ToUInt16(Value.ToArray(), Entities.AiIdOffset);
            }
            set
            {
                byte[] valueBytes = BitConverter.GetBytes(value);
                for (int i = 0; i < 2; i++)
                {
                    Value[Entities.AiIdOffset + i] = valueBytes[i];
                }
            }
        }

        public ushort HitboxWidth
        {
            get
            {
                return Value[Entities.HitboxWidthOffset];
            }
            set
            {
                Value[Entities.HitboxWidthOffset] = (byte)value;
            }
        }

        public ushort HitboxHeight
        {
            get
            {
                return Value[Entities.HitboxHeightOffset];
            }
            set
            {
                Value[Entities.HitboxHeightOffset] = (byte)value;
            }
        }
    }
}
