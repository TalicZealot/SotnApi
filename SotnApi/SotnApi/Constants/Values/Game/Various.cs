using SotnApi.Constants.Values.Game.Enums;
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
        public const int MapLenght = 2048;
        public const int MapItemsCollectedSize = 143;
        public const int UnderwaterPhysicsOn = 0x0090;
        public const uint RemoveMapRevealCheck = 0x14e00000;                        //BNE   $zero 0x0000
        public const uint DefaultVolumeSetInstruction = 0x84A5B668;                 //LH    $a1  -0x4998($a1)
        public const uint MuteVolumeSetInstruction = 0x34050000;                    //MOVE  $a1   0x0000
        public const uint DefaultMovementSpeedDirectionInstruction = 0x14620002;    //BNE   v1    v0 0x2
        public const uint FlippedMovementSpeedDirectionInstruction = 0x10620002;    //BEQ   v1    v0 0x2
        public const uint MonoStartingStereoSettingInstruction = 0x34020001;        //MOVE  v2    0x01
        public const uint StereoStartingStereoSettingInstruction = 0x34020000;      //MOVE  v2    0x00
        public const uint DefaultStopwatchTimerInstruction = 0x34020005;            //MOVE  v0    0x05

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
            { "lost painting", 0x00 },
            { "lost painting 1", 0x01 },
            { "lost painting 2", 0x02 },
            { "cursed sanctuary", 0x03 },
            { "cursed sanctuary 1", 0x04 },
            { "requiem for the gods", 0x05 },
            { "requiem for the gods 1", 0x06 },
            { "rainbow cemetary", 0x07 },
            { "rainbow cemetary 1", 0x08 },
            { "wood carving partita", 0x09 },
            { "wood carving partita 1", 0x0A },
            { "crystal teardrops", 0x0B },
            { "crystal teardrops 1", 0x0C },
            { "marble gallery", 0x0D },
            { "marble gallery 1", 0x0E },
            { "dracula castle", 0x0F },
            { "dracula castle 1", 0x10 },
            { "the tragic prince", 0x11 },
            { "the tragic prince 1", 0x12 },
            { "tower of evil mist", 0x13 },
            { "tower of evil mist 1", 0x14 },
            { "doorway of spirits", 0x15 },
            { "doorway of spirits 1", 0x16 },
            { "dance of pearls", 0x17 },
            { "dance of pearls 1", 0x18 },
            { "abandoned pit", 0x19 },
            { "abandoned pit 1", 0x1A },
            { "heavenly doorway", 0x1B },
            { "heavenly doorway 1", 0x1C },
            { "festival of servants", 0x1D },
            { "festival of servants 1", 0x1E },
            { "dance of illusions", 0x1F },
            { "dance of illusions 1", 0x20 },
            { "prologue", 0x21 },
            { "prologue 1", 0x22 },
            { "wandering ghosts", 0x23 },
            { "wandering ghosts 1", 0x24 },
            { "doorway to the abyss", 0x25 },
            { "doorway to the abyss 1", 0x26 },
            { "metamorphosis", 0x27 },
            { "metamorphosis 1", 0x28 },
            { "metamorphosis 2", 0x29 },
            { "ambient wind", 0x2A },
            { "ambient wind 1", 0x2B },
            { "ambient wind 2", 0x2C },
            { "ambient wind 3", 0x2D },
            { "dance of gold", 0x2E },
            { "dance of gold 1", 0x2F },
            { "enchanted banquet", 0x30 },
            { "enchanted banquet 1", 0x31 },
            { "prayer", 0x32 },
            { "prayer 1", 0x33 },
            { "death's ballad", 0x34 },
            { "death's ballad 1", 0x35 },
            { "blood relations", 0x36 },
            { "blood relations 1", 0x37 },
            { "finale toccata", 0x38 },
            { "finale toccata 1", 0x39 },
            { "black banquet", 0x3A },
            { "black banquet 1", 0x3B },
            { "i am the wind", 0x3C },
            { "silence", 0x3D },
            { "resting place", 0x3E },
            { "nocturne", 0x3F },
            { "moonlight nocturne", 0x40 }
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
            "Moonlight Nocturne"
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
            0x40
        };
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
        public static readonly List<Models.TeleportDestination> SafeLibraryCardZones = new List<Models.TeleportDestination>()
            {
                new Models.TeleportDestination { Zone = (ushort)Stage.MarbleGallery, Xpos = 125, Ypos = 125, Room = 40},
                new Models.TeleportDestination { Zone = (ushort)Stage.OuterWall, Xpos = 125, Ypos = 125, Room = 48},
                new Models.TeleportDestination { Zone = (ushort)Stage.LongLibrary, Xpos = 132, Ypos = 16, Room = 40},
                new Models.TeleportDestination { Zone = (ushort)Stage.Catacombs, Xpos = 125, Ypos = 125, Room = 40},
                new Models.TeleportDestination { Zone = (ushort)Stage.OlroxsQuarters, Xpos = 125, Ypos = 125, Room = 40},
                new Models.TeleportDestination { Zone = (ushort)Stage.AbandonedMine, Xpos = 125, Ypos = 125, Room = 24},
                new Models.TeleportDestination { Zone = (ushort)Stage.RoyalChapel, Xpos = 125, Ypos = 125, Room = 48},
                new Models.TeleportDestination { Zone = (ushort)Stage.CastleEntrance, Xpos = 125, Ypos = 125, Room = 48},
                new Models.TeleportDestination { Zone = (ushort)Stage.CenterCube, Xpos = 125, Ypos = 125, Room = 0},
                new Models.TeleportDestination { Zone = (ushort)Stage.UndergroundCaverns, Xpos = 125, Ypos = 125, Room = 48},
                new Models.TeleportDestination { Zone = (ushort)Stage.Colosseum, Xpos = 125, Ypos = 125, Room = 48},
                new Models.TeleportDestination { Zone = (ushort)Stage.CastleKeep, Xpos = 125, Ypos = 125, Room = 48},
                new Models.TeleportDestination { Zone = (ushort)Stage.AlchemyLaboratory, Xpos = 125, Ypos = 125, Room = 48},
                //new TeleportZone { Zone = (ushort)Zone.ClockTower, Xpos = 125, Ypos = 125, Room = 48},
                new Models.TeleportDestination { Zone = (ushort)Stage.Warp, Xpos = 125, Ypos = 125, Room = 48},
                new Models.TeleportDestination { Zone = (ushort)Stage.Nightmare, Xpos = 125, Ypos = 125, Room = 0},
                new Models.TeleportDestination { Zone = (ushort)Stage.AlchemyLaboratory2, Xpos = 125, Ypos = 125, Room = 0},
                new Models.TeleportDestination { Zone = (ushort)Stage.ClockTower2, Xpos = 125, Ypos = 125, Room = 0},
                new Models.TeleportDestination { Zone = (ushort)Stage.LongLibrary2, Xpos = 500, Ypos = 500, Room = 0},
                new Models.TeleportDestination { Zone = (ushort)Stage.Cerberus, Xpos = 125, Ypos = 125, Room = 0},
                new Models.TeleportDestination { Zone = (ushort)Stage.Hippogryph, Xpos = 125, Ypos = 125, Room = 0},
                new Models.TeleportDestination { Zone = (ushort)Stage.Doppleganger10, Xpos = 125, Ypos = 125, Room = 0},
                new Models.TeleportDestination { Zone = (ushort)Stage.Scylla, Xpos = 125, Ypos = 125, Room = 0},
                new Models.TeleportDestination { Zone = (ushort)Stage.MinotaurWerewolf, Xpos = 255, Ypos = 125, Room = 0},
                new Models.TeleportDestination { Zone = (ushort)Stage.Granfaloon, Xpos = 225, Ypos = 125, Room = 0},
                new Models.TeleportDestination { Zone = (ushort)Stage.Olrox, Xpos = 125, Ypos = 125, Room = 0},
                new Models.TeleportDestination { Zone = (ushort)Stage.BlackMarbleGallery, Xpos = 125, Ypos = 125, Room = 0},
                new Models.TeleportDestination { Zone = (ushort)Stage.ReverseOuterWall, Xpos = 125, Ypos = 125, Room = 0},
                new Models.TeleportDestination { Zone = (ushort)Stage.ForbiddenLibrary, Xpos = 125, Ypos = 125, Room = 8},
                new Models.TeleportDestination { Zone = (ushort)Stage.FloatingCatacombs, Xpos = 125, Ypos = 125, Room = 32},
                new Models.TeleportDestination { Zone = (ushort)Stage.DeathWingsLair, Xpos = 125, Ypos = 125, Room = 16},
                new Models.TeleportDestination { Zone = (ushort)Stage.Cave, Xpos = 125, Ypos = 125, Room = 0},
                new Models.TeleportDestination { Zone = (ushort)Stage.AntiChapel, Xpos = 125, Ypos = 125, Room = 48},
                new Models.TeleportDestination { Zone = (ushort)Stage.ReverseEntrance, Xpos = 125, Ypos = 125, Room = 16},
                new Models.TeleportDestination { Zone = (ushort)Stage.ReverseCaverns, Xpos = 125, Ypos = 125, Room = 0},
                new Models.TeleportDestination { Zone = (ushort)Stage.ReverseColosseum, Xpos = 125, Ypos = 125, Room = 8},
                new Models.TeleportDestination { Zone = (ushort)Stage.ReverseCastleKeep, Xpos = 125, Ypos = 125, Room = 40},
                new Models.TeleportDestination { Zone = (ushort)Stage.NecromancyLaboratory, Xpos = 125, Ypos = 125, Room = 40},
                //new TeleportZone { Zone = (ushort)Zone.ReverseClockTower, Xpos = 125, Ypos = 125, Room = 0}, //Darkwing
                //new TeleportZone { Zone = (ushort)Zone.ReverseClockTower, Xpos = 125, Ypos = 125, Room = 48},
                new Models.TeleportDestination { Zone = (ushort)Stage.ReverseWarp, Xpos = 125, Ypos = 125, Room = 8},
            };
    }
}
