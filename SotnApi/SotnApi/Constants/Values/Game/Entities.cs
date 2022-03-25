namespace SotnApi.Constants.Values.Game
{
    public static class Entities
    {
        public const int EnemyEntitiesCount = 131;
        public const int FriendEntitiesCount = 6;
        public const int Size = 146;
        public const int Poison = 0x81;
        public const int Curse = 1;
        public const int Stone = 2;
        public const int LockedOn = 2;
        public const int Slam = 0x25;
        public const int Offset = 0xBC;

        public const int XposOffset = 0x02;
        public const int YposOffset = 0x06;
        public const int AccelerationX = 0x08;
        public const int AccelerationY = 0x0C;
        public const int SpeedFractOffset = 0x09;
        public const int SpeedWholeOffset = 0xA;
        public const int SpeedVerticalFractOffset = 0xD;
        public const int SpeedVerticalWholeOffset = 0xE;
        public const int SpeedVerticalNegativeOffset = 0xF;
        public const int FacingOffset = 0x14;
        public const int PaletteOffset = 0x16;
        public const int ColorModeOffset = 0x18;
        public const int SpriteOffset = 0x28;
        public const int LockOnOffset = 0x2C;
        public const int ItemIndexOffset = 0x30; //RelicIndex
        public const int EnemyNameIndex = 0x3A;
        public const int DefOffset = 0x3A;
        public const int HitboxAutoToggleOffset = 0x3C;
        public const int HpOffset = 0x3E;
        public const int DamageOffset = 0x40;
        public const int DamageTypeAOffset = 0x42;
        public const int DamageTypeBOffset = 0x43;
        public const int HitboxWidthOffset = 0x46;
        public const int HitboxHeightOffset = 0x47;
        public const int InvincibilityFramesOffset = 0x49;
        public const int AnimationFrameIndexOffset = 0x50;
        public const int AnimationFrameDurationOffset = 0x52;
        public const int AnimationSetOffset = 0x54;
        public const int AnimationFrameOffset = 0x58;

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
