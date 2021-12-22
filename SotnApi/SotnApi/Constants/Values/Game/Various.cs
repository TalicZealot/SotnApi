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
        public static Dictionary<string, uint> MusicTracks = new Dictionary<string, uint>
        {
            { "Lost Painting", 0x00 },
            { "Cursed Sanctuary", 0x03 },
            { "Requiem for the Gods", 0x05 },
            { "Rainbow Cemetary", 0x07 },
            { "Wood Carving Partita", 0x09 },
            { "Crystal Teardrops", 0x0B },
            { "Marble Galery", 0x0D },
            { "Dracula Castle", 0x0F },
            { "The Tragic Prince", 0x11 },
            { "Tower of Evil Mist", 0x13 },
            { "Doorway of Spirits", 0x15 },
            { "Dance of Pearls", 0x17 },
            { "Abandoned Pit", 0x19 },
            { "Heavenly Doorway", 0x1B },
            { "Festival of Servants", 0x1D },
            { "Dance of Illusions", 0x1F },
            { "Prologue", 0x21 },
            { "Wandering Ghosts", 0x23 },
            { "Doorway to the Abyss", 0x25 },
            { "Metamorphosis", 0x27 },
            { "Metamorphosis 2", 0x29 },
            { "Ambient Wind", 0x2A },
            { "Dance of Gold", 0x2E },
            { "Enchanted Banquet", 0x30 },
            { "Prayer", 0x32 },
            { "Death's Ballad", 0x34 },
            { "Blood Relations", 0x36 },
            { "Finale Toccata", 0x38 },
            { "Black Banquet", 0x3A },
            { "I am the Wind", 0x3C },
            { "Silence", 0x3D },
            { "Resting Place", 0x3E },
            { "Nocturne", 0x3F },
            { "Moonlight Nocturne", 0x40 },
            { "Die monster", 0x58 },
            { "What is a man", 0x5D },
            { "Muted", 0x8C },
            { "Wait I beg of you", 0x92 },
            { "Thank you", 0xAD }
        };
        public static string[] MusicTrackTitles =
        {
            "Lost Painting",
            "Cursed Sanctuary",
            "Requiem for the Gods",
            "Rainbow Cemetary",
            "Wood Carving Partita",
            "Crystal Teardrops",
            "Marble Galery",
            "Dracula Castle",
            "The Tragic Prince",
            "Tower of Evil Mist",
            "Doorway of Spirits",
            "Dance of Pearls",
            "Abandoned Pit",
            "Heavenly Doorway",
            "Festival of Servants",
            "Dance of Illusions",
            "Prologue",
            "Wandering Ghosts",
            "Doorway to the Abyss",
            "Metamorphosis",
            "Metamorphosis 2",
            "Ambient Wind",
            "Dance of Gold",
            "Enchanted Banquet",
            "Prayer",
            "Death's Ballad",
            "Blood Relations",
            "Finale Toccata",
            "Black Banquet",
            "I am the Wind",
            "Silence",
            "Resting Place",
            "Nocturne",
            "Moonlight Nocturne",
            "Die monster",
            "What is a man",
            "Muted",
            "Wait I beg of you",
            "Thank you"
        };
        public static uint[] MusicTrackValues =
        {
            0x00,
            0x03,
            0x05,
            0x07,
            0x09,
            0x0B,
            0x0D,
            0x0F,
            0x11,
            0x13,
            0x15,
            0x17,
            0x19,
            0x1B,
            0x1D,
            0x1F,
            0x21,
            0x23,
            0x25,
            0x27,
            0x29,
            0x2A,
            0x2E,
            0x30,
            0x32,
            0x34,
            0x36,
            0x38,
            0x3A,
            0x3C,
            0x3D,
            0x3E,
            0x3F,
            0x40,
            0x58,
            0x5D,
            0x8C,
            0x92,
            0xAD
        };
        public static uint MuteValue = 0x8C;
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
