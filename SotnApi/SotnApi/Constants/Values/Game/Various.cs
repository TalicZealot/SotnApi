using SotnApi.Constants.Values.Game.Enums;
using SotnApi.Models;
using System.Collections.Generic;

namespace SotnApi.Constants.Values.Game
{
    public static class Various
    {
        public const long RowOffset = 0x800;
        public const uint MarbleGalleryArea = 0x28;
        public const uint MarbleGalleryDoorToCavernsRoom = 0x1C;
        public const uint MarbleGalleryBlueDoorRoom = 0x74;
        public const uint PrologueArea = 0x20;
        public const uint PrologueZone = 0x21;
        public const uint LoadingZone = 0x32;
        public const uint LibraryWarped = 0x78;
        public const uint CanSave = 0x20;
        public const uint CanWarp = 0x0E;
        public const int MapItemsCollectedSize = 143;
        public const int UnderwaterPhysicsOn = 0x0090;
        public const int DefaultMovementSpeedDirectionInstruction = 0x14620002; //BNE v1 v0 0x2
        public const int FlippedMovementSpeedDirectionInstruction = 0x10620002; //BEQ v1 v0 0x2

        public static readonly Dictionary<uint, char> CharacterMap = new Dictionary<uint, char> {
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
            {0x66, '\''},
            {0x69, '('},
            {0x6a, ')'},
            {0x6d, '['},
            {0x6e, ']'},
            {0x6f, '{'},
            {0x70, '}'},
            {0x7b, '+'},
            {0x7c, '-'}
        };
        public static readonly Dictionary<string, uint> MusicTracks = new Dictionary<string, uint>
        {
            { "lost painting", 0x01 },
            { "cursed sanctuary", 0x03 },
            { "requiem for the gods", 0x05 },
            { "rainbow cemetary", 0x07 },
            { "wood carving partita", 0x09 },
            { "crystal teardrops", 0x0b },
            { "marble gallery", 0x0d },
            { "dracula castle", 0x0f },
            { "the tragic prince", 0x11 },
            { "tower of evil mist", 0x13 },
            { "doorway of spirits", 0x15 },
            { "dance of pearls", 0x17 },
            { "abandoned pit", 0x19 },
            { "heavenly doorway", 0x1b },
            { "festival of servants", 0x1d },
            { "dance of illusions", 0x1f },
            { "prologue", 0x21 },
            { "wandering ghosts", 0x23 },
            { "doorway to the abyss", 0x25 },
            { "metamorphosis", 0x27 },
            { "metamorphosis 2", 0x29 },
            { "ambient wind", 0x2a },
            { "dance of gold", 0x2e },
            { "enchanted banquet", 0x30 },
            { "prayer", 0x32 },
            { "death's ballad", 0x34 },
            { "blood relations", 0x36 },
            { "finale toccata", 0x38 },
            { "black banquet", 0x3a },
            { "i am the wind", 0x3c },
            { "silence", 0x3d },
            { "resting place", 0x3e },
            { "nocturne", 0x3f },
            { "moonlight nocturne", 0x40 },
            { "die monster", 0x58 },
            { "what is a man", 0x5d },
            { "muted", 0x8c },
            { "wait i beg of you", 0x92 },
            { "thank you", 0xad }
        };
        public static readonly string[] MusicTrackTitles =
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
        public static readonly uint[] MusicTrackValues =
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
        public static readonly uint MuteValue = 0x8C;
        public static readonly string[] BossNames =
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
        public static readonly List<TeleportZone> SafeLibraryCardZones = new List<TeleportZone>()
            {
                new TeleportZone { Zone = (ushort)Zone.MarbleGallery, Xpos = 125, Ypos = 125, Room = 40},
                new TeleportZone { Zone = (ushort)Zone.OuterWall, Xpos = 125, Ypos = 125, Room = 48},
                new TeleportZone { Zone = (ushort)Zone.LongLibrary, Xpos = 132, Ypos = 16, Room = 40},
                new TeleportZone { Zone = (ushort)Zone.Catacombs, Xpos = 125, Ypos = 125, Room = 40},
                new TeleportZone { Zone = (ushort)Zone.OlroxsQuarters, Xpos = 125, Ypos = 125, Room = 40},
                new TeleportZone { Zone = (ushort)Zone.AbandonedMine, Xpos = 125, Ypos = 125, Room = 24},
                new TeleportZone { Zone = (ushort)Zone.RoyalChapel, Xpos = 125, Ypos = 125, Room = 48},
                new TeleportZone { Zone = (ushort)Zone.CastleEntrance, Xpos = 125, Ypos = 125, Room = 48},
                new TeleportZone { Zone = (ushort)Zone.CenterCube, Xpos = 125, Ypos = 125, Room = 0},
                new TeleportZone { Zone = (ushort)Zone.UndergroundCaverns, Xpos = 125, Ypos = 125, Room = 48},
                new TeleportZone { Zone = (ushort)Zone.Colosseum, Xpos = 125, Ypos = 125, Room = 48},
                new TeleportZone { Zone = (ushort)Zone.CastleKeep, Xpos = 125, Ypos = 125, Room = 48},
                new TeleportZone { Zone = (ushort)Zone.AlchemyLaboratory, Xpos = 125, Ypos = 125, Room = 48},
                //new TeleportZone { Zone = (ushort)Zone.ClockTower, Xpos = 125, Ypos = 125, Room = 48},
                new TeleportZone { Zone = (ushort)Zone.Warp, Xpos = 125, Ypos = 125, Room = 48},
                new TeleportZone { Zone = (ushort)Zone.Nightmare, Xpos = 125, Ypos = 125, Room = 0},
                new TeleportZone { Zone = (ushort)Zone.SlograGaibon, Xpos = 125, Ypos = 125, Room = 0},
                new TeleportZone { Zone = (ushort)Zone.Karasuman, Xpos = 125, Ypos = 125, Room = 0},
                new TeleportZone { Zone = (ushort)Zone.LesserDemon, Xpos = 500, Ypos = 500, Room = 0},
                new TeleportZone { Zone = (ushort)Zone.Cerberus, Xpos = 125, Ypos = 125, Room = 0},
                new TeleportZone { Zone = (ushort)Zone.Hippogryph, Xpos = 125, Ypos = 125, Room = 0},
                new TeleportZone { Zone = (ushort)Zone.Doppleganger10, Xpos = 125, Ypos = 125, Room = 0},
                new TeleportZone { Zone = (ushort)Zone.Scylla, Xpos = 125, Ypos = 125, Room = 0},
                new TeleportZone { Zone = (ushort)Zone.MinotaurWerewolf, Xpos = 255, Ypos = 125, Room = 0},
                new TeleportZone { Zone = (ushort)Zone.Granfaloon, Xpos = 225, Ypos = 125, Room = 0},
                new TeleportZone { Zone = (ushort)Zone.Olrox, Xpos = 125, Ypos = 125, Room = 0},
                new TeleportZone { Zone = (ushort)Zone.BlackMarbleGallery, Xpos = 125, Ypos = 125, Room = 0},
                new TeleportZone { Zone = (ushort)Zone.ReverseOuterWall, Xpos = 125, Ypos = 125, Room = 0},
                new TeleportZone { Zone = (ushort)Zone.ForbiddenLibrary, Xpos = 125, Ypos = 125, Room = 8},
                new TeleportZone { Zone = (ushort)Zone.FloatingCatacombs, Xpos = 125, Ypos = 125, Room = 32},
                new TeleportZone { Zone = (ushort)Zone.DeathWingsLair, Xpos = 125, Ypos = 125, Room = 16},
                new TeleportZone { Zone = (ushort)Zone.Cave, Xpos = 125, Ypos = 125, Room = 0},
                new TeleportZone { Zone = (ushort)Zone.AntiChapel, Xpos = 125, Ypos = 125, Room = 48},
                new TeleportZone { Zone = (ushort)Zone.ReverseEntrance, Xpos = 125, Ypos = 125, Room = 16},
                new TeleportZone { Zone = (ushort)Zone.ReverseCaverns, Xpos = 125, Ypos = 125, Room = 0},
                new TeleportZone { Zone = (ushort)Zone.ReverseColosseum, Xpos = 125, Ypos = 125, Room = 8},
                new TeleportZone { Zone = (ushort)Zone.ReverseCastleKeep, Xpos = 125, Ypos = 125, Room = 40},
                new TeleportZone { Zone = (ushort)Zone.NecromancyLaboratory, Xpos = 125, Ypos = 125, Room = 40},
                //new TeleportZone { Zone = (ushort)Zone.ReverseClockTower, Xpos = 125, Ypos = 125, Room = 0}, //Darkwing
                //new TeleportZone { Zone = (ushort)Zone.ReverseClockTower, Xpos = 125, Ypos = 125, Room = 48},
                new TeleportZone { Zone = (ushort)Zone.ReverseWarp, Xpos = 125, Ypos = 125, Room = 8},
            };
    }
}
