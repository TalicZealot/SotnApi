using System.Collections.Generic;

namespace SotnApi.Constants.Values.Game
{
    public static class Various
    {
        public static long RowOffset = 0x800;
        public static uint MarbleGalleryArea = 0x28;
        public static uint MarbleGalleryDoorToCavernsRoom = 0x1C;
        public static uint MarbleGalleryBlueDoorRoom = 0x74;
        public static uint PrologueArea = 0x20;
        public static uint PrologueZone = 0x21;
        public static uint LoadingZone = 0x32;
        public static uint LibraryWarped = 0x78;
        public static uint CanSave = 0x20;
        public static int MapItemsCollectedSize = 143;

        public static Dictionary<uint, char> CharacterMap = new Dictionary<uint, char> {
            {0x43, ','},
            {0x44, '.'},
            {0x46, ':'},
            {0x47, ';'},
            {0x48, '?'},
            {0x49, '!'},
            {0x4d, '`'},
            {0x4e, '"'},
            {0x4f, '^'},
            {0x51, '_'},
            {0x60, '~'},
            {0x66, '\\'},
            {0x69, '('},
            {0x6a, ')'},
            {0x6d, '['},
            {0x6e, ']'},
            {0x6f, '{'},
            {0x70, '}'},
            {0x7b, '+'},
            {0x7c, '-'}
        };

        public static string[] BossNames =
        {
            "Slogra",
            "Gaibon",
            "Doppleganger10",
            "Minotaur",
            "Werewolf",
            "LesserDemon",
            "Karasuman",
            "Hippogryph",
            "Olrox",
            "Succubus",
            "ScyllaWorm",
            "Scylla",
            "Cerberus",
            "Granfaloon",
            "Richter",
            "DarkwingBat",
            "Creature",
            "Doppleganger40",
            "Death",
            "Galamoth",
            "Medusa",
            "Akmodan",
            "Trevor",
            "Sypha",
            "Grant",
            "Beelzebub",
            "Shaft",
            "Dracula"
        };

    }
}
