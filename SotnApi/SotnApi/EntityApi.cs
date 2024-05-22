using BizHawk.Client.Common;
using SotnApi.Constants.Addresses;
using SotnApi.Constants.Values.Game;
using SotnApi.Interfaces;
using SotnApi.Models;
using System;
using System.Collections.Generic;

namespace SotnApi
{
    public sealed class EntityApi : IEntityApi
    {
        private readonly IMemoryApi memAPI;

        public EntityApi(IMemoryApi? memAPI)
        {
            if (memAPI == null) { throw new ArgumentNullException("Memory API is null"); }
            this.memAPI = memAPI;
        }

        public long FindEntityFrom(List<ushort> enemyIds, bool enemy = true)
        {
            long address = enemy ? Game.EnemyEntitiesStart : Game.FriendlyEntitiesStart;
            int count = enemy ? Entities.EnemyEntitiesCount : Entities.FriendEntitiesCount;

            for (int i = 0; i < count; i++)
            {
                Entity current = GetLiveEntity(address);
                bool match = false;

                if (current.UpdateFunctionAddress == 0)
                {
                    address += Entities.Size;
                    continue;
                }

                for (int j = 0; j < enemyIds.Count; j++)
                {
                    if (current.EnemyId == enemyIds[j])
                    {
                        match = true;
                        break;
                    }
                }

                if (match)
                {
                    return address;
                }
                else
                {
                    address += Entities.Size;
                }
            }

            return 0;
        }

        public List<long> GetAllEntities()
        {
            List<long> ActorAddresses = new();
            long start = Game.EnemyEntitiesStart;
            for (int i = 0; i < Entities.EnemyEntitiesCount; i++)
            {
                long hitboxWidth = memAPI.ReadByte(start + Entities.HitboxWidth);
                long hitboxHeight = memAPI.ReadByte(start + Entities.HitboxHeight);
                long hp = memAPI.ReadU16(start + Entities.Hp);
                long damage = memAPI.ReadU16(start + Entities.Damage);
                long sprite = memAPI.ReadU16(start + 22);

                if (hitboxWidth > 0 || hitboxHeight > 0 || hp > 0 || damage > 0 || sprite > 0)
                {
                    ActorAddresses.Add(start);
                }
                start += Entities.Size;
            }

            return ActorAddresses;
        }

        public List<long> GetAllEntities(List<ushort> enemyIds)
        {
            List<long> ActorAddresses = new();
            long address = Game.EnemyEntitiesStart;
            for (int i = 0; i < Entities.EnemyEntitiesCount; i++)
            {
                Entity current = GetLiveEntity(address);

                for (int j = 0; j < enemyIds.Count; j++)
                {
                    if (current.EnemyId == enemyIds[j])
                    {
                        ActorAddresses.Add(address);
                        break;
                    }
                }

                address += Entities.Size;
            }

            return ActorAddresses;
        }

        public List<byte> GetEntity(long address)
        {
            return new List<byte>(memAPI.ReadByteRange(address, Entities.Size));
        }

        public Entity GetLiveEntity(long address)
        {
            return new Entity(address, memAPI);
        }

        /// <summary>
        /// Scans memory for an empty entity slot.
        /// </summary>
        /// <returns>
        /// The address where the slot starts. Or 0 if a free slot was not found.
        /// </returns>
        private long FindAvailableEntitySlot(bool enemy = true)
        {
            long address = enemy ? Game.EnemyEntitiesStart : Game.FriendlyEntitiesStart;
            int count = enemy ? Entities.EnemyEntitiesCount : Entities.FriendEntitiesCount;
            for (int i = 0; i < count; i++)
            {
                Entity entity = GetLiveEntity(address);
                bool reserved = false;

                for (int j = 0; j < Entities.ReservedSlots.Length; j++)
                {
                    if (address == Entities.ReservedSlots[j])
                    {
                        reserved = true;
                    }
                }

                if (entity.HitboxWidth == 0 && entity.HitboxHeight == 0 && entity.Hp == 0 && entity.Damage == 0 && entity.UpdateFunctionAddress == 0 && !reserved)
                {
                    return address;
                }
                address += Entities.Size;
            }

            return 0;
        }

        public long SpawnEntity(Entity entity, bool enemy = true)
        {
            long slot = FindAvailableEntitySlot(enemy);

            if (slot > 0)
            {
                memAPI.WriteByteRange(slot, entity.Data.AsReadOnly());
            }

            return slot;
        }
    }
}
