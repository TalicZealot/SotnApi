using System.Collections.Generic;

namespace SotnApi.Constants.Addresses
{
    public static class Strings
    {
        //Bosses
        public const long Slogra = 0x0E07C4;
        public const long Gaibon = 0x0E0794;
        public const long Doppleganger40 = 0x0E0614;
        public const long Minotaur = 0x0E087C;
        public const long Werewolf = 0x0E0870;
        public const long LesserDemon = 0x0E0CC0;
        public const long Karasuman = 0x0E0730;
        public const long Hippogryph = 0x0E06E8;
        public const long Olrox = 0x0E0C30;
        public const long Succubus = 0x0E0668;
        public const long ScyllaWorm = 0x0E0700;
        public const long Scylla = 0x0E0710;
        public const long Cerberus = 0x0E063C;
        public const long Granfaloon = 0x0E06F4;
        public const long Richter = 0x0E06BC;
        public const long DarkwingBat = 0x0E0748;
        public const long Creature = 0x0E0624;
        public const long Doppleganger10 = 0x0E079C;
        public const long Death = 0x0E0648;
        public const long Galamoth = 0x0E0888;
        public const long Medusa = 0x0E0634;
        public const long Akmodan = 0x0E0768;
        public const long Trevor = 0x0E068C;
        public const long Sypha = 0x0E0674;
        public const long Grant = 0x0E0680;
        public const long Beelzebub = 0x0E069C;
        public const long Shaft = 0x0E0650;
        public const long Dracula = 0x0E0914;
        //Enemies
        public static readonly Dictionary<string, long> BossNameAddresses = new Dictionary<string, long>
        {
            {"Slogra", 0x0E07C4},
            {"Gaibon", 0x0E0794},
            {"Doppleganger40", 0x0E0614},
            {"Minotaur", 0x0E087C},
            {"Werewolf", 0x0E0870},
            {"LesserDemon", 0x0E0CC0},
            {"Karasuman", 0x0E0730},
            {"Hippogryph", 0x0E06E8},
            {"Olrox", 0x0E0C30},
            {"Succubus", 0x0E0668},
            {"ScyllaWorm", 0x0E0700 },
            {"Scylla", 0x0E0710},
            {"Cerberus", 0x0E063C},
            {"Granfaloon", 0x0E06F4},
            {"Richter", 0x0E06BC},
            {"DarkwingBat", 0x0E0748},
            {"Creature", 0x0E0624},
            {"Doppleganger10", 0x0E079C},
            {"Death", 0x0E0648},
            {"Galamoth", 0x0E0888},
            {"Medusa", 0x0E0634},
            {"Akmodan", 0x0E0768},
            {"Trevor", 0x0E068C},
            {"Sypha", 0x0E0674},
            {"Grant", 0x0E0680},
            {"Beelzebub", 0x0E069C},
            {"Shaft", 0x0E0650},
            {"Dracula", 0x0E0914}
        };
        public static readonly Dictionary<string, long> EnemyNameAddresses = new Dictionary<string, long>
        {
            {"Guardian", 0xe05d8},
            {"BlueVenusWeed", 0xe05e4},
            {"Minotaur", 0xe05f8},
            {"StoneSkull", 0xe0604},
            {"KillerFish", 0xe0658},
            {"Schmoo", 0xe06a8},
            {"Scarecrow", 0xe06b0},
            {"Archer", 0xe06d0},
            {"MedusaHead", 0xe06d8},
            {"Balloonpod", 0xe0718},
            {"Imp", 0xe0728},
            {"AxeKnight", 0x0E0D2C},
            {"Fishhead", 0xe073c},
            {"Cloakedknight", 0xe0758},
            {"Tinman", 0xe0774},
            {"Lion", 0xe0780},
            {"SkullLord", 0xe0788},
            {"MagicTome", 0xe07ac},
            {"Spellbook", 0xe07b8},
            {"Harpy", 0xe07cc},
            {"Malachi", 0xe07d4},
            {"Ctulhu", 0xe07e0},
            {"Salome", 0xe07e8},
            {"VandalSword", 0xe07f0},
            {"HuntingGirl", 0xe0800},
            {"Gremlin", 0xe0810},
            {"Azaghal", 0xe081c},
            {"SalemWitch", 0xe0828},
            {"FrozenHalf", 0xe0838},
            {"GhostDancer", 0xe0848},
            {"Mudman", 0xe0858},
            {"Paranthropus", 0xe0860},
            {"SniperofGoth", 0xe0894},
            {"OuijaTable", 0xe08a4},
            {"Blade", 0xe08b4},
            {"Gurkha", 0xe08bc},
            {"SpikedBall", 0xe08c4},
            {"Bitterfly", 0xe08d4},
            {"CornerGuard", 0xe08e0},
            {"Slinger", 0xe08f0},
            {"Warg", 0xe08fc},
            {"GreaterDemon", 0xe0904},
            {"RockKnight", 0xe0920},
            {"BombKnight", 0xe0930},
            {"VenusWeed", 0xe0940},
            {"Corpseweed", 0xe094c},
            {"Thornweed", 0xe0958},
            {"CaveTroll", 0xe0964},
            {"WargRider", 0xe0970},
            {"FireWarg", 0xe097c},
            {"Dhuron", 0xe0988},
            {"DragonRider", 0xe0990},
            {"OruburosRider", 0xe09a0},
            {"Oruburos", 0xe09b0},
            {"Orobourous", 0xe09bc},
            {"Spear", 0xe09c8},
            {"PuppetSword", 0xe09d0},
            {"SpectralSword", 0xe09e0},
            {"ValhallaKnight", 0xe09f4},
            {"Lossoth", 0xe0a08},
            {"Poltergeist", 0xe0a14},
            {"SpectralSword2", 0xe0a24},
            {"WingedGuard", 0xe0a34},
            {"NovaSkeleton", 0xe0a44},
            {"BladeSoldier", 0xe0a54},
            {"BladeMaster", 0xe0a64},
            {"Skull", 0xe0a74},
            {"Yorick", 0xe0a7c},
            {"BoneHalberd", 0xe0a84},
            {"JackO'Bones", 0xe0a94},
            {"BlackCrow", 0xe0aa4},
            {"BlueRaven", 0xe0ab0},
            {"Tombstone", 0xe0abc},
            {"GraveKeeper", 0xe0ac8},
            {"Zombie", 0xe0ad8},
            {"BoneArcher", 0xe0ae0},
            {"Frog", 0xe0af0},
            {"Toad", 0xe0af8},
            {"BoneScimitar", 0xe0b00},
            {"DodoBird", 0xe0b10},
            {"BoneMusket", 0xe0b1c},
            {"FrozenShade", 0xe0b2c},
            {"PlateLord", 0xe0b3c},
            {"SpearGuard", 0xe0b48},
            {"BonePillar", 0xe0b58},
            {"Ectoplasm", 0xe0b68},
            {"StoneRose", 0xe0b74},
            {"SkeletonApe", 0xe0b80},
            {"SpittleBone", 0xe0b90},
            {"FireDemon", 0xe0ba0},
            {"DiscusLord", 0xe0bac},
            {"Skeleton", 0xe0bbc},
            {"HellfireBeast", 0xe0bc8},
            {"BloodSkeleton", 0xe0bd8},
            {"FlailGuard", 0xe0be8},
            {"PhantomSkull", 0xe0bf8},
            {"Slime", 0xe0c08},
            {"LargeSlime", 0xe0c10},
            {"Wereskeleton", 0xe0c20},
            {"Marionette", 0xe0c38},
            {"FleaRider", 0xe0c44},
            {"BoneArk", 0xe0c50},
            {"WhiteDragon", 0xe0c5c},
            {"FleaArmor", 0xe0c6c},
            {"FleaMan", 0xe0c78},
            {"DarkOctopus", 0xe0c84},
            {"BlackPanther", 0xe0c94},
            {"ArmorLord", 0xe0ca4},
            {"Gorgon", 0xe0cb0},
            {"Merman", 0xe0cb8},
            {"Owl", 0xe0cd0},
            {"OwlKnight", 0xe0cd8},
            {"Diplocephalus", 0xe0ce4},
            {"FlyingZombie", 0xe0cf4},
            {"BloodyZombie", 0xe0d04},
            {"Skelerang", 0xe0d14},
            {"SwordLord", 0xe0d20},
        };
        public static readonly Dictionary<string, long> ItemNameAddresses = new Dictionary<string, long>
        {
            {"Library card", 0x0DD200},
            {"Gurthang", 0x0DD998}
        };
    }
}
