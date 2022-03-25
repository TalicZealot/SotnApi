﻿using System.Collections.Generic;

namespace SotnApi.Constants.Addresses
{
    public static class Game
    {
        public static readonly Dictionary<string, long> BossToggles = new Dictionary<string, long>
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
        public static readonly Dictionary<string, uint> MusicTracks = new Dictionary<string, uint>
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

        public const long Status = 0x03C734;
        public const long Transition = 0x03C9A4;
        public const long Loading = 0x03CF7C;
        public const long MapOpen = 0x0974A4;
        public const long MenuOpen = 0x0973EC;
        public const long MainMenuCategory = 0x03C9A8;
        public const long EquipMenuOpen = 0x137948;
        public const long RelicMenuOpen = 0x1FFF6A;
        public const long SecondCastle = 0x1E5458;
        public const long SettingsMenuOpen = 0x03D04E;
        public const long MapXPos = 0x0730B0;
        public const long MapYPos = 0x0730B4;
        public const long Room = 0x1375BC;
        public const long Area = 0x1375BD;
        public const long Zone2 = 0x0974A0;
        public const long Hours = 0x097C30;
        public const long Minutes = 0x097C34;
        public const long Seconds = 0x097C38;
        public const long Frames = 0x097C3C;
        public const long Character = 0x03C9A0;
        public const long Prologue = 0x20;
        public const long LibraryCard = 0x1FFC99;
        public const long TeleportToLevelEntrance = 0x03C9A4;
        public const long State = 0x073404;
        public const long FriendlyEntitiesStart = 0x073F98;
        public const long EnemyEntitiesStart = 0x0762d8;
        public const long VramMapStart = 0x08AE80;
        public const long SeedStart = 0x1A78B4;
        public const long PresetStart = 0x1A78D4;
        public const long MapStart = 0x06BBDC;
        public const long MapEnd = 0x06C30B;
        public const long CanSave = 0x03C708;
        public const long CanWarp = 0x03C710;
        public const long MapItemsCollectedStart = 0x03BEE0;
        public const long UnderwaterPhysics = 0x097448;
        public const long Music = 0x138458;
        public const long TeleportDestination = 0x097C98;
    }
}
