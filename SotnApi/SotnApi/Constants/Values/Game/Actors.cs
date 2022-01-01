namespace SotnApi.Constants.Values.Game
{
    public static class Actors
    {
        public static int EnemiesCount = 131;
        public static int FriendActorsCount = 6;
        public static int Size = 146;
        public static int Poison = 0x81;
        public static int Curse = 1;
        public static int Stone = 2;
        public static int Slam = 0x25;
        public static int Offset = 0xBC;
        public static int XposOffset = 0x02;
        public static int YposOffset = 0x06;
        public static int SpeedFractOffset = 0x08;
        public static int SpeedWholeOffset = 0x09;
        public static int FacingOffset = 0x14;
        public static int PaletteOffset = 0x16;
        public static int ColorModeOffset = 0x18;
        public static int SpriteOffset = 0x28;
        public static int ItemIndexOffset = 0x30; //RelicIndex
        public static int EnemyNameIndex = 0x3A;
        public static int HitboxAutoToggleOffset = 0x3C;
        public static int HpOffset = 0x3E;
        public static int DamageOffset = 0x40;
        public static int DamageTypeAOffset = 0x42;
        public static int DamageTypeBOffset = 0x43;
        public static int HitboxWidthOffset = 0x46;
        public static int HitboxHeightOffset = 0x47;
        public static int DefOffset = 0x3A;
        public static long[] ReservedSlots =
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
        };
    }
}
