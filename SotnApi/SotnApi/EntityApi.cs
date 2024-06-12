using BizHawk.Client.Common;
using SotnApi.Constants.Addresses;
using SotnApi.Constants.Values.Game;
using SotnApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using Entity = SotnApi.Models.Entity;

namespace SotnApi
{
    public sealed class EntityApi : IEntityApi
    {
        private readonly IMemoryApi memAPI;
        private readonly List<byte> clearEntity = new List<byte>(new byte[Entities.Size]);

        public EntityApi(IMemoryApi? memAPI)
        {
            if (memAPI == null) { throw new ArgumentNullException("Memory API is null"); }
            this.memAPI = memAPI;
        }

        public long FindEntity(ushort enemyId, bool enemy = true)
        {
            long address = enemy ? Game.EnemyEntitiesStart : Game.FriendlyEntitiesStart;
            int count = enemy ? Entities.EnemyEntitiesCount : Entities.FriendEntitiesCount;

            for (int i = 0; i < count; i++)
            {
                ushort currentEnemyId = (ushort)memAPI.ReadU16(address + Entities.EnemyId);

                if (currentEnemyId == enemyId)
                {
                    return address;
                }
                address += Entities.Size;
            }

            return 0;
        }

        public long FindEntityFrom(List<ushort> enemyIds, bool enemy = true)
        {
            long address = enemy ? Game.EnemyEntitiesStart : Game.FriendlyEntitiesStart;
            int count = enemy ? Entities.EnemyEntitiesCount : Entities.FriendEntitiesCount;

            for (int i = 0; i < count; i++)
            {
                ushort currentEnemyId = (ushort)memAPI.ReadU16(address + Entities.EnemyId);

                for (int j = 0; j < enemyIds.Count; j++)
                {
                    if (currentEnemyId == enemyIds[j])
                    {
                        return address;
                    }
                }
                address += Entities.Size;
            }

            return 0;
        }

        public long FindEntityFrom(List<Entity> entities, bool enemy = true)
        {
            long address = enemy ? Game.EnemyEntitiesStart : Game.FriendlyEntitiesStart;
            int count = enemy ? Entities.EnemyEntitiesCount : Entities.FriendEntitiesCount;

            for (int i = 0; i < count; i++)
            {
                Entity current = GetLiveEntity(address);

                for (int j = 0; j < entities.Count; j++)
                {
                    if (current.EnemyId == entities[j].EnemyId && current.ObjectId == entities[j].ObjectId)
                    {
                        return address;
                    }
                }
                address += Entities.Size;
            }

            return 0;
        }

        public List<long> GetAllEntities()
        {
            List<long> ActorAddresses = new();
            long start = Game.EnemyEntitiesStart;
            for (int i = 0; i < Entities.EnemyEntitiesCount; i++)
            {
                uint hitboxWidth = memAPI.ReadByte(start + Entities.HitboxWidth);
                uint hitboxHeight = memAPI.ReadByte(start + Entities.HitboxHeight);
                uint hp = memAPI.ReadU16(start + Entities.Hp);
                uint damage = memAPI.ReadU16(start + Entities.Damage);
                uint sprite = memAPI.ReadU16(start + 22);
                uint enemyId = memAPI.ReadU16(start + Entities.EnemyId);
                uint objectId = memAPI.ReadU16(start + Entities.ObjectId);

                if (hitboxWidth > 0 || hitboxHeight > 0 || hp > 0 || damage > 0 || sprite > 0 || enemyId > 0 || objectId > 0)
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
                ushort currentEnemyId = (ushort)memAPI.ReadU16(address + Entities.EnemyId);

                for (int j = 0; j < enemyIds.Count; j++)
                {
                    if (currentEnemyId == enemyIds[j])
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

                if (entity.HitboxWidth == 0 && entity.HitboxHeight == 0 && entity.Hp == 0 && entity.Damage == 0 && entity.UpdateFunctionAddress == 0 && entity.ObjectId == 0 && !reserved)
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

        public void FreeEntity(long address)
        {
            memAPI.WriteByteRange(address, clearEntity.AsReadOnly());
        }
    }
}
