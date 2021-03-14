using System.Collections.Generic;

namespace SotnApi.Constants.Addresses
{
    public static class Game
    {
        public static Dictionary<string, long> BossToggles = new Dictionary<string, long>
        {
            { "Akmodan", 0x03CA74 },
            { "Beelzebub", 0x03CA48 },
            { "Cerberus", 0x03CA5C },
            { "Darkwing", 0x03CA78 },
            { "Death", 0x03CA58 },
            { "Dopple10", 0x03CA30 },
            { "Dopple40", 0x03CA70 },
            { "Trio", 0x03CA54 },
            { "Galamoth", 0x03CA7C },
            { "Granfaloon", 0x03CA34 },
            { "Hippogryph", 0x03CA44 },
            { "Karasuman", 0x03CA50 },
            { "LesserDemon", 0x03CA6C },
            { "Medusa", 0x03CA64 },
            { "Minotaur&Werewolf", 0x03CA38 },
            { "Olrox", 0x03CA2C },
            { "Scylla", 0x03CA3C },
            { "Slogra&Gaibon", 0x03CA40 },
            { "Succubus", 0x03CA4C },
            { "Creature", 0x03CA68 }
        };

        public static long Status = 0x03C734;
        public static long StatusTransition = 0x03C9A4;
        public static long Loading = 0x03CF7C;
        public static long MapOpen = 0x0974A4;
        public static long MenuOpen = 0x0973EC;
        public static long SecondCastle = 0x1E5458;
        public static long SettingsMenuOpen = 0x03D04E;
        public static long Room = 0x1375BC;
        public static long Area = 0x1375BD;
        public static long Zone = 0x138458;
        public static long Zone2 = 0x0974A0;
        public static long Hours = 0x097C30;
        public static long Character = 0x03C9A0;
        public static long Prologue = 0x20;
        public static long LibraryCard = 0x1FFC99;
        public static long TeleportToLevelEntrance = 0x03C9A4;
        public static long State = 0x073404;
        public static long ActorsStart = 0x07650C;
        public static long VramMapStart = 0x08AE80;
        public static long SeedStart = 0x1A78B4;
        public static long PresetStart = 0x1A78D4;
    }
}
