using System;
using BizHawk.Client.Common;
using SotnApi.Constants.Addresses.Alucard;
using SotnApi.Constants.Values.Alucard;
using SotnApi.Constants.Values.Alucard.Enums;
using SotnApi.Interfaces;
using Effects = SotnApi.Constants.Addresses.Alucard.Effects;

namespace SotnApi
{
    public class AlucardApi : IAlucardApi
    {
        private readonly IMemoryApi memAPI;

        public AlucardApi(IMemoryApi? memAPI)
        {
            if (memAPI == null) throw new ArgumentNullException(nameof(memAPI));
            this.memAPI = memAPI;
        }

        public uint CurrentHp
        {
            get
            {
                return memAPI.ReadByte(Stats.CurrentHP);
            }
            set
            {
                memAPI.WriteByte(Stats.CurrentHP, value);
            }
        }

        public uint MaxtHp
        {
            get
            {
                return memAPI.ReadByte(Stats.MaxHP);
            }
            set
            {
                memAPI.WriteByte(Stats.MaxHP, value);
            }
        }

        public uint CurrentMp
        {
            get
            {
                return memAPI.ReadByte(Stats.CurrentMana);
            }
            set
            {
                memAPI.WriteByte(Stats.CurrentMana, value);
            }
        }

        public uint MaxtMp
        {
            get
            {
                return memAPI.ReadByte(Stats.MaxMana);
            }
            set
            {
                memAPI.WriteByte(Stats.MaxMana, value);
            }
        }

        public uint CurrentHearts
        {
            get
            {
                return memAPI.ReadByte(Stats.CurrentHearts);
            }
            set
            {
                memAPI.WriteByte(Stats.CurrentHearts, value);
            }
        }

        public uint MaxtHearts
        {
            get
            {
                return memAPI.ReadByte(Stats.MaxHearts);
            }
            set
            {
                memAPI.WriteByte(Stats.MaxHearts, value);
            }
        }

        public uint Str
        {
            get
            {
                return memAPI.ReadByte(Stats.Str);
            }
            set
            {
                memAPI.WriteByte(Stats.Str, value);
            }
        }

        public uint Con
        {
            get
            {
                return memAPI.ReadByte(Stats.Con);
            }
            set
            {
                memAPI.WriteByte(Stats.Con, value);
            }
        }

        public uint Int
        {
            get
            {
                return memAPI.ReadByte(Stats.Int);
            }
            set
            {
                memAPI.WriteByte(Stats.Int, value);
            }
        }

        public uint Lck
        {
            get
            {
                return memAPI.ReadByte(Stats.Lck);
            }
            set
            {
                memAPI.WriteByte(Stats.Lck, value);
            }
        }

        public uint Gold
        {
            get
            {
                return memAPI.ReadByte(Stats.Gold);
            }
            set
            {
                memAPI.WriteByte(Stats.Gold, value);
            }
        }

        public uint Experiecne
        {
            get
            {
                return memAPI.ReadByte(Stats.Experience);
            }
            set
            {
                memAPI.WriteByte(Stats.Experience, value);
            }
        }

        public uint Rooms
        {
            get
            {
                return memAPI.ReadByte(Stats.Rooms);
            }
            set
            {
                memAPI.WriteByte(Stats.Rooms, value);
            }
        }

        public uint WarpsFirstCastle
        {
            get
            {
                return memAPI.ReadByte(Stats.WarpsFirstCastle);
            }
            set
            {
                memAPI.WriteByte(Stats.WarpsFirstCastle, value);
            }
        }

        public uint WarpsSecondCastle
        {
            get
            {
                return memAPI.ReadByte(Stats.WarpsSecondCastle);
            }
            set
            {
                memAPI.WriteByte(Stats.WarpsSecondCastle, value);
            }
        }

        public uint WingsmashHorizontalSpeed
        {
            get
            {
                return memAPI.ReadByte(Speeds.WingsmashHorizontal);
            }
            set
            {
                memAPI.WriteByte(Speeds.WingsmashHorizontal, value);
            }
        }

        public uint WalkingWholeSpeed
        {
            get
            {
                return memAPI.ReadByte(Speeds.WalkingWhole);
            }
            set
            {
                memAPI.WriteByte(Speeds.WalkingWhole, value);
            }
        }

        public uint WalkingFractSpeed
        {
            get
            {
                return memAPI.ReadByte(Speeds.WalkingFract);
            }
            set
            {
                memAPI.WriteByte(Speeds.WalkingFract, value);
            }
        }

        public uint JumpingHorizontalWholeSpeed
        {
            get
            {
                return memAPI.ReadByte(Speeds.JumpingHorizontalWhole);
            }
            set
            {
                memAPI.WriteByte(Speeds.JumpingHorizontalWhole, value);
            }
        }

        public uint JumpingHorizontalFractSpeed
        {
            get
            {
                return memAPI.ReadByte(Speeds.JumpingHorizontalFract);
            }
            set
            {
                memAPI.WriteByte(Speeds.JumpingHorizontalFract, value);
            }
        }

        public uint FallingHorizontalWholeSpeed
        {
            get
            {
                return memAPI.ReadByte(Speeds.FallingHorizontalWhole);
            }
            set
            {
                memAPI.WriteByte(Speeds.FallingHorizontalWhole, value);
            }
        }

        public uint FallingHorizontalFractSpeed
        {
            get
            {
                return memAPI.ReadByte(Speeds.FallingHorizontalFract);
            }
            set
            {
                memAPI.WriteByte(Speeds.FallingHorizontalFract, value);
            }
        }

        public sbyte WolfDashTopRightSpeed
        {
            get
            {
                return (sbyte)memAPI.ReadByte(Speeds.WolfDashTopRight);
            }
            set
            {
                memAPI.WriteByte(Speeds.WolfDashTopRight, (uint)value);
            }
        }

        public sbyte WolfDashTopLeftSpeed
        {
            get
            {
                return (sbyte)memAPI.ReadByte(Speeds.WolfDashTopLeft);
            }
            set
            {
                memAPI.WriteByte(Speeds.WolfDashTopLeft, (uint)value);
            }
        }

        public uint BackdashDecel
        {
            get
            {
                return memAPI.ReadByte(Speeds.BackdashDecel);
            }
            set
            {
                memAPI.WriteByte(Speeds.BackdashDecel, value);
            }
        }

        public uint RightHand
        {
            get
            {
                return memAPI.ReadByte(Inventory.RightHandSlot);
            }
            set
            {
                memAPI.WriteByte(Inventory.RightHandSlot, value);
            }
        }

        public uint LeftHand
        {
            get
            {
                return memAPI.ReadByte(Inventory.LeftHandSlot);
            }
            set
            {
                memAPI.WriteByte(Inventory.LeftHandSlot, value);
            }
        }

        public uint Armor
        {
            get
            {
                return memAPI.ReadByte(Inventory.ArmorSlot);
            }
            set
            {
                memAPI.WriteByte(Inventory.ArmorSlot, value);
            }
        }

        public uint Helm
        {
            get
            {
                return memAPI.ReadByte(Inventory.HelmSlot);
            }
            set
            {
                memAPI.WriteByte(Inventory.HelmSlot, value);
            }
        }

        public uint Cloak
        {
            get
            {
                return memAPI.ReadByte(Inventory.CloakSlot);
            }
            set
            {
                memAPI.WriteByte(Inventory.CloakSlot, value);
            }
        }

        public uint Accessory1
        {
            get
            {
                return memAPI.ReadByte(Inventory.AccessorySlot1);
            }
            set
            {
                memAPI.WriteByte(Inventory.AccessorySlot1, value);
            }
        }

        public uint Accessory2
        {
            get
            {
                return memAPI.ReadByte(Inventory.AccessorySlot2);
            }
            set
            {
                memAPI.WriteByte(Inventory.AccessorySlot2, value);
            }
        }

        public Subweapon Subweapon
        {
            get
            {
                return (Subweapon)memAPI.ReadByte(Inventory.Subweapon);
            }
            set
            {
                memAPI.WriteByte(Inventory.Subweapon, (uint)value);
            }
        }

        public uint DarkMetamorphasisTimer
        {
            get
            {
                return memAPI.ReadByte(Timers.DarkMetamorphasis);
            }
            set
            {
                memAPI.WriteByte(Timers.DarkMetamorphasis, value);
            }
        }

        public uint AttackPotionTimer
        {
            get
            {
                return memAPI.ReadByte(Timers.AttackPotion);
            }
            set
            {
                memAPI.WriteByte(Timers.AttackPotion, value);
            }
        }

        public uint DefencePotionTimer
        {
            get
            {
                return memAPI.ReadByte(Timers.DefencePotion);
            }
            set
            {
                memAPI.WriteByte(Timers.DefencePotion, value);
            }
        }

        public uint InvincibilityTimer
        {
            get
            {
                return memAPI.ReadByte(Timers.Invincibility);
            }
            set
            {
                memAPI.WriteByte(Timers.Invincibility, value);
            }
        }

        public uint ShineTimer
        {
            get
            {
                return memAPI.ReadByte(Timers.Shine);
            }
            set
            {
                memAPI.WriteByte(Timers.Shine, value);
            }
        }

        public bool HasRelic(Relic name)
        {
            return memAPI.ReadByte(Relics.AllRelics[name.ToString()]) > 0;
        }

        public void TakeRelicByName(Relic name)
        {
            memAPI.WriteByte(Relics.AllRelics[name.ToString()], 0);
        }

        public void GrantRelicByName(Relic name)
        {
            uint value = name.ToString().Contains("Card") ? 1u : 3u;
            memAPI.WriteByte(Relics.AllRelics[name.ToString()], value);
        }

        public bool HasItemInInventory(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            int item = Equipment.Items.IndexOf(name);
            if (item == -1) throw new ArgumentException("Invalid item name!");

            uint value = memAPI.ReadByte(Inventory.HandQuantityStart + item);
            return value > 0;
        }

        public void GrantItemByName(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            int item = Equipment.Items.IndexOf(name);
            if (item == -1) throw new ArgumentException("Invalid item name!");

            uint itemCount = memAPI.ReadByte(Inventory.HandQuantityStart + item);
            memAPI.WriteByte(Inventory.HandQuantityStart + item, itemCount + 1);
            if (itemCount == 0)
            {
                SortItemInventory((uint)item);
            }
        }

        public void Heal(uint ammount)
        {
            memAPI.WriteS16(Effects.HealAmmount, (int)ammount);
            memAPI.WriteByte(Effects.HealTrigger, 1);
        }

        public void ClearInventory()
        {
            for (int i = 0; i < Equipment.Items.Count; i++)
            {
                if (ViableItem(i))
                {
                    memAPI.WriteByte(Inventory.HandQuantityStart + i, 0);
                }
            }
        }

        private void SortItemInventory(uint item)
        {
            int countsBase = Equipment.HandCount + 1;
            long slotBaseAddress = 0;
            int max = 0;
            if (item <= Equipment.HandCount)
            {
                max = Equipment.HandCount;
                slotBaseAddress = Inventory.HandInventoryStart;
                countsBase = 0;
            }
            else if (item > Equipment.HandCount && item <= 1 + Equipment.HandCount + Equipment.ArmorCount - 1)
            {
                max = Equipment.ArmorCount;
                slotBaseAddress = Inventory.ArmorInventoryStart;
            }
            else if (item > Equipment.HandCount + Equipment.ArmorCount - 1 && item <= 2 + Equipment.HandCount + Equipment.ArmorCount - 1 + Equipment.HelmCount)
            {
                max = Equipment.HelmCount;
                slotBaseAddress = Inventory.HelmInventoryStart;
            }
            else if (item > Equipment.HandCount + Equipment.ArmorCount - 1 + Equipment.HelmCount && item <= 3 + Equipment.HandCount + Equipment.ArmorCount - 1 + Equipment.HelmCount + Equipment.CloakCount)
            {
                max = Equipment.CloakCount;
                slotBaseAddress = Inventory.CloakInventoryStart;
            }
            else if (item > Equipment.HandCount + Equipment.ArmorCount - 1 + Equipment.HelmCount + Equipment.CloakCount && item <= 4 + Equipment.HandCount + Equipment.ArmorCount - 1 + Equipment.HelmCount + Equipment.CloakCount + Equipment.AccessoryCount)
            {
                max = Equipment.AccessoryCount;
                slotBaseAddress = Inventory.AccessoryInventoryStart;
            }
            else
            {
                max = Equipment.ArmorCount;
                slotBaseAddress = Inventory.ArmorInventoryStart;
            }

            for (int i = 0; i < max; i++)
            {
                uint slotValue = memAPI.ReadByte(slotBaseAddress + i);
                uint slotItemCount = memAPI.ReadByte(Inventory.HandQuantityStart + slotValue + countsBase);
                if (slotItemCount == 0)
                {
                    long itemSlot = FindItemInventorySlot(slotBaseAddress, max, item - countsBase);
                    if (itemSlot == 0)
                    {
                        break;
                    }
                    memAPI.WriteByte(slotBaseAddress + i, (uint)(item - countsBase));
                    memAPI.WriteByte(itemSlot, slotValue);
                    break;
                }
            }
        }

        private long FindItemInventorySlot(long slotBaseAddress, int max, long item)
        {
            for (int j = 0; j <= max; j++)
            {
                uint slotValue = memAPI.ReadByte(slotBaseAddress + j);
                if (slotValue == item)
                {
                    return slotBaseAddress + j;
                }
            }
            Console.WriteLine($"Item slot for index {item} not found in the inventory category starting at {slotBaseAddress:X} and ending at {max}th slot.");
            return 0;
        }

        private bool ViableItem(int i)
        {
            return Equipment.Items[i] != "empty hand" && Equipment.Items[i] != "----helm" && Equipment.Items[i] != "----armor"
                                && Equipment.Items[i] != "----cloak" && Equipment.Items[i] != "----accessory";
        }
    }
}
