using SotnApi.Constants.Values.Game;
using System;
using System.Collections.Generic;

namespace SotnApi.Models
{
    /// <summary>
    /// An entity object that can be rendered in-game. Enemies, projectiles, items, hitboxes, interactable objects.
    /// </summary>
    public class Actor
    {
        public Actor(List<byte>? entity = null)
        {
            if (entity != null)
            {
                this.Value = entity;
            }
            else
            {
                Value = new List<byte>();
                for (int i = 0; i <= Actors.Size; i++)
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
                return BitConverter.ToUInt16(Value.ToArray(), Actors.XposOffset);
            }
            set
            {
                byte[] valueBytes = BitConverter.GetBytes(value);
                for (int i = 0; i < 2; i++)
                {
                    Value[Actors.XposOffset + i] = valueBytes[i];
                }
            }
        }

        public ushort Ypos
        {
            get
            {
                return BitConverter.ToUInt16(Value.ToArray(), Actors.YposOffset);
            }
            set
            {
                byte[] valueBytes = BitConverter.GetBytes(value);
                for (int i = 0; i < 2; i++)
                {
                    Value[Actors.YposOffset + i] = valueBytes[i];
                }
            }
        }

        public ushort SpeedHorizontalFract
        {
            get
            {
                return Value[Actors.SpeedFractOffset];
            }
            set
            {
                Value[Actors.SpeedFractOffset] = (byte)value;
            }
        }

        public ushort SpeedHorizontal
        {
            get
            {
                return Value[Actors.SpeedWholeOffset];
            }
            set
            {
                Value[Actors.SpeedWholeOffset] = (byte)value;
            }
        }

        public ushort SpeedVerticalFract
        {
            get
            {
                return Value[Actors.SpeedVerticalFractOffset];
            }
            set
            {
                Value[Actors.SpeedVerticalFractOffset] = (byte)value;
            }
        }

        public ushort SpeedVertical
        {
            get
            {
                return Value[Actors.SpeedVerticalWholeOffset];
            }
            set
            {
                Value[Actors.SpeedVerticalWholeOffset] = (byte)value;
            }
        }

        public ushort AutoToggle
        {
            get
            {
                return Value[Actors.HitboxAutoToggleOffset];
            }
            set
            {
                Value[Actors.HitboxAutoToggleOffset] = (byte)value;
            }
        }

        public ushort Hp
        {
            get
            {
                return BitConverter.ToUInt16(Value.ToArray(), Actors.HpOffset);
            }
            set
            {
                byte[] valueBytes = BitConverter.GetBytes(value);
                for (int i = 0; i < 2; i++)
                {
                    Value[Actors.HpOffset + i] = valueBytes[i];
                }
            }
        }

        public ushort Def
        {
            get
            {
                return BitConverter.ToUInt16(Value.ToArray(), Actors.DefOffset);
            }
            set
            {
                byte[] valueBytes = BitConverter.GetBytes(value);
                for (int i = 0; i < 2; i++)
                {
                    Value[Actors.DefOffset + i] = valueBytes[i];
                }
            }
        }

        public ushort Damage
        {
            get
            {
                return BitConverter.ToUInt16(Value.ToArray(), Actors.DamageOffset);
            }
            set
            {
                byte[] valueBytes = BitConverter.GetBytes(value);
                for (int i = 0; i < 2; i++)
                {
                    Value[Actors.DamageOffset + i] = valueBytes[i];
                }
            }
        }

        public uint DamageTypeA
        {
            get
            {
                return Value[Actors.DamageTypeAOffset];
            }
            set
            {
                Value[Actors.DamageTypeAOffset] = (byte)value;
            }
        }

        public uint DamageTypeB
        {
            get
            {
                return Value[Actors.DamageTypeBOffset];
            }
            set
            {
                Value[Actors.DamageTypeBOffset] = (byte)value;
            }
        }

        public ushort Palette
        {
            get
            {
                return Value[Actors.PaletteOffset];
            }
            set
            {
                Value[Actors.PaletteOffset] = (byte)value;
            }
        }

        public ushort ColorMode
        {
            get
            {
                return Value[Actors.ColorModeOffset];
            }
            set
            {
                Value[Actors.ColorModeOffset] = (byte)value;
            }
        }
        //AI id
        public ushort Sprite
        {
            get
            {
                return BitConverter.ToUInt16(Value.ToArray(), Actors.SpriteOffset);
            }
            set
            {
                byte[] valueBytes = BitConverter.GetBytes(value);
                for (int i = 0; i < 2; i++)
                {
                    Value[Actors.SpriteOffset + i] = valueBytes[i];
                }
            }
        }

        public ushort HitboxWidth
        {
            get
            {
                return Value[Actors.HitboxWidthOffset];
            }
            set
            {
                Value[Actors.HitboxWidthOffset] = (byte)value;
            }
        }

        public ushort HitboxHeight
        {
            get
            {
                return Value[Actors.HitboxHeightOffset];
            }
            set
            {
                Value[Actors.HitboxHeightOffset] = (byte)value;
            }
        }
    }
}
