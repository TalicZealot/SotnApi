using System.Collections.Generic;

namespace SotnApi.Constants.Addresses
{
	internal static class Strings
	{
		//Bosses
		public static long Slogra = 0x0E07C4;
		public static long Gaibon = 0x0E0794;
		public static long Doppleganger40 = 0x0E0614;
		public static long Minotaur = 0x0E087C;
		public static long Werewolf = 0x0E0870;
		public static long LesserDemon = 0x0E0CC0;
		public static long Karasuman = 0x0E0730;
		public static long Hippogryph = 0x0E06E8;
		public static long Olrox = 0x0E0C30;
		public static long Succubus = 0x0E0668;
		public static long ScyllaWorm = 0x0E0700;
		public static long Scylla = 0x0E0710;
		public static long Cerberus = 0x0E063C;
		public static long Granfaloon = 0x0E06F4;
		public static long Richter = 0x0E06BC;
		public static long DarkwingBat = 0x0E0748;
		public static long Creature = 0x0E0624;
		public static long Doppleganger10 = 0x0E079C;
		public static long Death = 0x0E0648;
		public static long Galamoth = 0x0E0888;
		public static long Medusa = 0x0E0634;
		public static long Akmodan = 0x0E0768;
		public static long Trevor = 0x0E068C;
		public static long Sypha = 0x0E0674;
		public static long Grant = 0x0E0680;
		public static long Beelzebub = 0x0E069C;
		public static long Shaft = 0x0E0650;
		public static long Dracula = 0x0E0914;
		//Enemies
		public static long MedusaHead = 0x0E06D8;
		public static long FleaMan = 0x0E0C78;
		public static Dictionary<string, long> BossNameAddresses = new Dictionary<string, long>
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
		public static Dictionary<string, long> EnemyNameAddresses = new Dictionary<string, long>
		{
			{"MedusaHead", 0x0E06D8},
			{"FleaMan", 0x0E0C78},
		};
	}
}
