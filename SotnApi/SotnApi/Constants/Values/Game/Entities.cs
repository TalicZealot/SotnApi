﻿namespace SotnApi.Constants.Values.Game
{
    public static class Entities
    {
        public const int EnemyEntitiesCount = 190;
        public const int FriendEntitiesCount = 6;
        public const ushort Poison = 0x0081;
        public const ushort Curse = 0x0100;
        public const ushort Stone = 0x0202;
        public const ushort LockedOn = 0x2;
        public const ushort Slam = 0x0025;
        public const byte Size = 0xBC;
        //Entity Offsets
        public const int Xpos = 0x00;
        public const int Ypos = 0x04;
        public const int AccelerationX = 0x08;
        public const int AccelerationY = 0x0C;
        public const int Facing = 0x14;
        public const int Palette = 0x16;
        public const int DrawMode = 0x18;
        public const int DrawFlags = 0x19;
        public const int RotX = 0x1A;
        public const int RotY = 0x1C;
        public const int RotZ = 0x1E;
        public const int RotPivotX = 0x20;
        public const int RotPivotY = 0x22;
        public const int ZPriority = 0x24;
        public const int ObjectId = 0x26;
        public const int UpdateFunctionAddress = 0x28;
        public const int Step = 0x2C;
        public const int Step2 = 0x2E;
        public const int SubId = 0x30; // Item/Relic Index
        public const int ObjectRoomIndex = 0x32;
        public const int Flags = 0x34;
        public const int Unk38 = 0x38;
        public const int EnemyId = 0x3A;
        public const int HitboxState = 0x3C;
        public const int Hp = 0x3E;
        public const int Damage = 0x40;
        public const int DamageType = 0x42;
        public const int HitboxWidth = 0x46;
        public const int HitboxHeight = 0x47;
        public const int InvincibilityFrames = 0x49;
        public const int Unk4A = 0x4A;
        public const int AnimationFunctionAddress = 0x4C;
        public const int AnimationFrameIndex = 0x50;
        public const int AnimationFrameDuration = 0x52;
        public const int AnimationSet = 0x54;
        public const int AnimationCurrentFrame = 0x56;
        public const int StunFrames = 0x58;
        public const int Unk5A = 0x5A;
        public const int PrimIndex = 0x64;
        public const int HitEffect = 0x6A;
        //* 0x64 */ s32 firstPolygonIndex;

        //Spawning entities in these can cause relics not to spawn.
        public static readonly long[] ReservedSlots =
        {
            0x076e98,
            0x076d20,
            0x076ba8,
            0x0767fc,
            0x0768b8,
            0x076a30,
            0x0786d4,
            0x0765c8,
            0x07a958,
            0x076450
        };
    }
}
