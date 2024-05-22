using BizHawk.Client.Common;
using SotnApi.Constants.Values.Game;
using System;
using System.Collections.Generic;

namespace SotnApi.Models
{
    /// <summary>
    /// An object that can be rendered in-game or a live in-memory instance. Enemies, projectiles, items, hitboxes, interactable objects.
    /// </summary>
    public sealed class Entity
    {
        private readonly IMemoryApi memAPI;
        private bool isLive = false;

        public Entity(long address, IMemoryApi? memAPI)
        {
            Address = address;
            if (memAPI == null) { throw new ArgumentNullException("Memory API is null"); }
            this.memAPI = memAPI;
            this.isLive = true;
        }
        public Entity(List<byte>? entity = null)
        {
            if (entity != null)
            {
                this.Data = entity;
            }
            else
            {
                Data = new List<byte>(new byte[Entities.Size]);
            }
        }

        public long Address { get; set; }
        public List<byte> Data { get; set; }

        public double Xpos
        {
            get
            {
                return ReadFixedPoint1616(Entities.Xpos);
            }
            set
            {
                WriteFixedPoint1616(Entities.Xpos, value);
            }
        }
        public double Ypos
        {
            get
            {
                return ReadFixedPoint1616(Entities.Ypos);
            }
            set
            {
                WriteFixedPoint1616(Entities.Ypos, value);
            }
        }
        public double AccelerationX
        {
            get
            {
                return ReadFixedPoint1616(Entities.AccelerationX);
            }
            set
            {
                WriteFixedPoint1616(Entities.AccelerationX, value);
            }
        }
        public double AccelerationY
        {
            get
            {
                return ReadFixedPoint1616(Entities.AccelerationY);
            }
            set
            {
                WriteFixedPoint1616(Entities.AccelerationY, value);
            }
        }
        public ushort Facing
        {
            get
            {
                return ReadU16(Entities.Facing);
            }
            set
            {
                WriteU16(Entities.Facing, value);
            }
        }
        public ushort Palette
        {
            get
            {
                return ReadU16(Entities.Palette);
            }
            set
            {
                WriteU16(Entities.Palette, value);
            }
        }
        public byte DrawMode
        {
            get
            {
                return ReadByte(Entities.DrawMode);
            }
            set
            {
                WriteByte(Entities.DrawMode, value);
            }
        }
        public byte DrawFlags
        {
            get
            {
                return ReadByte(Entities.DrawFlags);
            }
            set
            {
                WriteByte(Entities.DrawFlags, value);
            }
        }
        public ushort ZPriority
        {
            get
            {
                return ReadU16(Entities.ZPriority);
            }
            set
            {
                WriteU16(Entities.ZPriority, value);
            }
        }
        public ushort ObjectId
        {
            get
            {
                return ReadU16(Entities.ObjectId);
            }
            set
            {
                WriteU16(Entities.ObjectId, value);
            }
        }
        public uint UpdateFunctionAddress
        {
            get
            {
                return ReadU32(Entities.UpdateFunctionAddress);
            }
            set
            {
                WriteU32(Entities.UpdateFunctionAddress, value);
            }
        }
        public ushort Step
        {
            get
            {
                return ReadU16(Entities.Step);
            }
            set
            {
                WriteU16(Entities.Step, value);
            }
        }
        public ushort Step2
        {
            get
            {
                return ReadU16(Entities.Step2);
            }
            set
            {
                WriteU16(Entities.Step2, value);
            }
        }
        public ushort SubId
        {
            get
            {
                return ReadU16(Entities.SubId);
            }
            set
            {
                WriteU16(Entities.SubId, value);
            }
        }
        public ushort ObjectRoomIndex
        {
            get
            {
                return ReadU16(Entities.ObjectRoomIndex);
            }
            set
            {
                WriteU16(Entities.ObjectRoomIndex, value);
            }
        }
        public uint Flags
        {
            get
            {
                return ReadU32(Entities.Flags);
            }
            set
            {
                WriteU32(Entities.Flags, value);
            }
        }
        public ushort EnemyId
        {
            get
            {
                return ReadU16(Entities.EnemyId);
            }
            set
            {
                WriteU16(Entities.EnemyId, value);
            }
        }
        public byte AutoToggle
        {
            get
            {
                return ReadByte(Entities.HitboxAutoToggle);
            }
            set
            {
                WriteByte(Entities.HitboxAutoToggle, value);
            }
        }
        public short Hp
        {
            get
            {
                return ReadS16(Entities.Hp);
            }
            set
            {
                WriteS16(Entities.Hp, value);
            }
        }
        public ushort Damage
        {
            get
            {
                return ReadU16(Entities.Damage);
            }
            set
            {
                WriteU16(Entities.Damage, value);
            }
        }
        public byte DamageTypeA
        {
            get
            {
                return ReadByte(Entities.DamageTypeA);
            }
            set
            {
                WriteByte(Entities.DamageTypeA, value);
            }
        }
        public byte DamageTypeB
        {
            get
            {
                return ReadByte(Entities.DamageTypeB);
            }
            set
            {
                WriteByte(Entities.DamageTypeB, value);
            }
        }
        public byte HitboxWidth
        {
            get
            {
                return ReadByte(Entities.HitboxWidth);
            }
            set
            {
                WriteByte(Entities.HitboxWidth, value);
            }
        }
        public byte HitboxHeight
        {
            get
            {
                return ReadByte(Entities.HitboxHeight);
            }
            set
            {
                WriteByte(Entities.HitboxHeight, value);
            }
        }
        public byte InvincibilityFrames
        {
            get
            {
                return ReadByte(Entities.InvincibilityFrames);
            }
            set
            {
                WriteByte(Entities.InvincibilityFrames, value);
            }
        }
        public byte AnimationFrameIndex
        {
            get
            {
                return ReadByte(Entities.AnimationFrameIndex);
            }
            set
            {
                WriteByte(Entities.AnimationFrameIndex, value);
            }
        }
        public byte AnimationFrameDuration
        {
            get
            {
                return ReadByte(Entities.AnimationFrameDuration);
            }
            set
            {
                WriteByte(Entities.AnimationFrameDuration, value);
            }
        }
        public byte AnimationSet
        {
            get
            {
                return ReadByte(Entities.AnimationSet);
            }
            set
            {
                WriteByte(Entities.AnimationSet, value);
            }
        }
        public byte AnimationCurrentFrame
        {
            get
            {
                return ReadByte(Entities.AnimationCurrentFrame);
            }
            set
            {
                WriteByte(Entities.AnimationCurrentFrame, value);
            }
        }

        private void WriteByte(int offset, byte value)
        {
            if (isLive)
            {
                memAPI.WriteByte(Address + offset, value);
            }
            else
            {
                Data[offset] = value;
            }
        }
        private void WriteU16(int offset, ushort value)
        {
            if (isLive)
            {
                memAPI.WriteU16(Address + offset, value);
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    byte[] valueBytes = BitConverter.GetBytes(value);
                    Data[offset + i] = valueBytes[i];

                }
            }
        }
        private void WriteU32(int offset, uint value)
        {
            if (isLive)
            {
                memAPI.WriteU32(Address + offset, value);
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    byte[] valueBytes = BitConverter.GetBytes(value);
                    Data[offset + i] = valueBytes[i];

                }
            }
        }
        private void WriteS16(int offset, short value)
        {
            if (isLive)
            {
                memAPI.WriteS16(Address + offset, value);
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    byte[] valueBytes = BitConverter.GetBytes(value);
                    Data[offset + i] = valueBytes[i];

                }
            }
        }
        private void WriteS32(int offset, int value)
        {
            if (isLive)
            {
                memAPI.WriteS32(Address + offset, value);
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    byte[] valueBytes = BitConverter.GetBytes(value);
                    Data[offset + i] = valueBytes[i];

                }
            }
        }
        private byte ReadByte(int offset)
        {
            if (isLive)
            {
                return (byte)memAPI.ReadByte(Address + offset);
            }
            else
            {
                return Data[offset];
            }
        }
        private ushort ReadU16(int offset)
        {
            if (isLive)
            {
                return (ushort)memAPI.ReadU16(Address + offset);
            }
            else
            {
                return BitConverter.ToUInt16(Data.ToArray(), offset);
            }
        }
        private uint ReadU32(int offset)
        {
            if (isLive)
            {
                return memAPI.ReadU32(Address + offset);
            }
            else
            {
                return BitConverter.ToUInt32(Data.ToArray(), offset);
            }
        }
        private short ReadS16(int offset)
        {
            if (isLive)
            {
                return (short)memAPI.ReadS16(Address + offset);
            }
            else
            {
                return BitConverter.ToInt16(Data.ToArray(), offset);
            }
        }
        private int ReadS32(int offset)
        {
            if (isLive)
            {
                return memAPI.ReadS32(Address + offset);
            }
            else
            {
                return BitConverter.ToInt32(Data.ToArray(), offset);
            }
        }
        private double ReadFixedPoint1616(int offset)
        {
            uint rawValue = ReadU32(offset);
            return ((int)rawValue / 65536.0);
        }
        private void WriteFixedPoint1616(int offset, double value)
        {
            WriteU32(offset, (uint)(value * 65536.0));
        }
    }
}
